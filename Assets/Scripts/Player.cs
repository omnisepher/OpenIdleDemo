using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    public InputAction playerControls;

    private Vector2 moveDirection; //TODO 2D Axis Joystick

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Awake()
    {
        if (GetComponent<Rigidbody>())
        {
            rb = GetComponent<Rigidbody>();
        }
        if (GetComponent<Animator>())
        {
            anim = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
        anim.SetFloat("Speed", rb.velocity.magnitude);
        Vector3 nextDir = new Vector3(-moveDirection.y, 0, moveDirection.x);
        if (nextDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(nextDir);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.y * GameManager.speed * -1.0f, rb.velocity.y, moveDirection.x * GameManager.speed);
    }
}
