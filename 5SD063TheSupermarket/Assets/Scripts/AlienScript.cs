using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlienScript : MonoBehaviour
{
    public float speed, waitTime, startwaitTime;
    public Transform[] positions;
    public int randomPos;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;
        startwaitTime = 3.0f;

        waitTime = startwaitTime;
        randomPos = Random.Range(0, positions.Length);
    }

    // Update is called once per frame
    void Update()
    {
        // movement

        transform.position = Vector3.MoveTowards(transform.position, positions[randomPos].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, positions[randomPos].position) < 0.2)
        {
            if (waitTime <= 0)
            {
                randomPos = Random.Range(0, positions.Length);
                waitTime = startwaitTime;
            }
            else { waitTime -= Time.deltaTime; }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
