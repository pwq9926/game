using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cashout : MonoBehaviour
{
    public UnityEvent win;
    public UnityEvent lose;
    public bool playsound;
    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        playsound = false;
    }

}





