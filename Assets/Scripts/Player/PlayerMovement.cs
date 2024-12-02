using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float PlayerMoveSpeed;
    [SerializeField] private float PlayerSprintSpeed;
    [SerializeField] private double PSSHolder;
    [SerializeField] private Rigidbody Rb;
    [SerializeField] private Vector3 Movement;
    [SerializeField] private bool sprinting;

    private void Start()
    {
        if (1 > PlayerMoveSpeed)
        {
            PlayerMoveSpeed = 1;
        }

        PSSHolder= PlayerMoveSpeed * 1.5;
        PlayerSprintSpeed = Convert.ToSingle(PSSHolder);
    }

    private void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprinting = false;
        }
    }

    private void FixedUpdate()
    {
        if (!sprinting)
        {
            Rb.MovePosition(Rb.position + Movement * PlayerMoveSpeed * Time.fixedDeltaTime);
        }
        else if (sprinting)
        {
            Rb.MovePosition(Rb.position + Movement * PlayerSprintSpeed * Time.fixedDeltaTime);                          // next on agenda... Player rolling, and movement from attacks( likely to be used in the attacks code borrowing from this script)
        }
    }
}