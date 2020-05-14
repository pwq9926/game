using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherScript : MonoBehaviour
{
    public float swearTime;
    public bool activeBubble;
    public GameObject swearBubble;

    // Start is called before the first frame update
    void Start()
    {
        activeBubble = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!activeBubble)
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
