using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAI : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;

    private bool IsStop;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        IsStop = false;
    }

    void FixedUpdate()
    {
        if (!IsStop)
        {
            anim.SetBool("Running", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DeadZone")
        {
            anim.SetBool("Running", false);
            IsStop = true;
        }
    }
}
