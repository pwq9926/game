using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtCamera : MonoBehaviour
{

    private void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer == null)
            Debug.LogError("No SpriteRenderer On GameObject");
        else
            renderer.flipX = true;
    }
    // Update is called once per frame 
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }

}
