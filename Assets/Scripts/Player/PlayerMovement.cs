using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerMoveSpeed;
    [SerializeField] private float PlayerSprintSpeed;
    [SerializeField] private double PSSHolder;
    [SerializeField] public Rigidbody Rb;
    [SerializeField] public Vector3 Movement;
    [SerializeField] private bool sprinting;

    public Transform playerBottom;

    public EventInstance playerFootsteps;

    public bool canMove;
    public bool sliding;

    private void Start()
    {
        playerFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.playerFootsteps);

        UpdateSound();

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
        

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    sprinting = true;
        //}
        //else if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    sprinting = false;
        //}
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

        UpdateSound();
    }

    private void UpdateSound()
    {
        playerFootsteps.set3DAttributes(RuntimeUtils.To3DAttributes(playerBottom.position));

        if (Rb.velocity.x != 0f && !sliding && canMove)
        {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);

            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                playerFootsteps.start();
        }
        else if (Rb.velocity.z != 0f && !sliding && canMove)
        {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);

            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                playerFootsteps.start();
        }
        else if (Rb.velocity.z != 0f && Rb.velocity.x != 0f && !sliding && canMove)
        {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);

            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                playerFootsteps.start();
        }
        else
        {
            playerFootsteps.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}