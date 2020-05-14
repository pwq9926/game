using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletpaperScript : MonoBehaviour
{
    public float speed, waitTime, startwaitTime;
    public Transform[] positions;
    public int Pos;
    private TPwaypoints wpoints;
    private int wpointIndex;

    void Start()
    {
        wpoints = GameObject.FindGameObjectWithTag("waypointTP").GetComponent<TPwaypoints>();
        speed = 1.0f;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wpoints.waypoints[wpointIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, wpoints.waypoints[wpointIndex].position) < 0.1f)
        {
            if (wpointIndex < wpoints.waypoints.Length - 1)
            {
                wpointIndex++;
            }
            else { wpointIndex = 0; }
        }
    }
}
