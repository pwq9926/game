using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaScript : MonoBehaviour
{
    public float speed, waitTime, startwaitTime, swearTime;
    public GameObject swearBubble;
    public Transform[] positions;
    private Waypoints wpoints;
    private int wpointIndex;
    public bool activeBubble;

    // Start is called before the first frame update
    void Start()
    {
        wpoints = GameObject.FindGameObjectWithTag("waypoint").GetComponent<Waypoints>();
        speed = 0.2f;
        startwaitTime = 3.0f;
        waitTime = startwaitTime;

        activeBubble = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region movement

        transform.position = Vector3.MoveTowards(transform.position, wpoints.waypoints[wpointIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, wpoints.waypoints[wpointIndex].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (wpointIndex < wpoints.waypoints.Length - 1)
                {
                    wpointIndex++;
                }
                else { wpointIndex = 0; }
                waitTime = startwaitTime;
            }
            else { waitTime -= Time.deltaTime; }
        }
        #endregion

        #region swearbubble

        if(!activeBubble)
        {
            swearBubble.SetActive(false);
        }
        else
        {
            swearBubble.SetActive(true);
            if (swearTime > 0)
            {
                swearTime -= Time.deltaTime;
            }
            if (swearTime <= 0)
            {
                activeBubble = false;
            }
        }

        #endregion
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "player")
        {
            activeBubble = true;
            swearTime = 2.0f;
        }
    }
}
