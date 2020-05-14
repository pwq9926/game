using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class testPlayer : MonoBehaviour
{
    public Animator animator;
    public UnityEvent donepicking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    animator.SetBool("ispicking", true);
        //}
        //else { animator.SetBool("ispicking", false); }
    }


    public void donePicking()
    {
        animator.SetBool("ispicking", false);
    }
}
