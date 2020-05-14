using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInterpolation : MonoBehaviour
{
    public enum MoveType
    {
        LERP,
        SLERP,
        MoveTowards
    }

    public Transform target = null;
    public float strength = 0.1f;
    public MoveType type = MoveType.LERP;
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //switch(type)
        //{
        //    case MoveType.LERP: transform.position = Vector3.Lerp(transform.position, target.position, strength); break;
        //    case MoveType.SLERP: transform.position = Vector3.Slerp(transform.position, target.position, strength); break;
        //    case MoveType.MoveTowards: transform.position = Vector3.MoveTowards(transform.position, target.position, strength); break;

        //}
    }
}
