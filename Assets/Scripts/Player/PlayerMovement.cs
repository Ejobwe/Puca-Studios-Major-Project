using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerMoveSpeed;
    [SerializeField] private float PlayerSprintSpeed;
    [SerializeField] private double PSSHolder;
    [SerializeField] public Rigidbody Rb;
    [SerializeField] public Vector3 Movement;
    [SerializeField] private bool sprinting;

    public bool canMove;
    public bool sliding;

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
        if (!sprinting && canMove && !sliding)
        {
            Rb.velocity = new Vector3(Movement.x * PlayerMoveSpeed, 0, Movement.z * PlayerMoveSpeed);
        }
        else if (sprinting && canMove && !sliding)
        {
            Rb.MovePosition(Rb.position + Movement * PlayerSprintSpeed * Time.fixedDeltaTime);                          // next on agenda... Player rolling, and movement from attacks( likely to be used in the attacks code borrowing from this script)
        }
    }
}