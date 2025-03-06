using UnityEngine;
using System.Collections;
using FMOD.Studio;
using FMODUnity;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform playerBottom;

    public bool camTran;

    public float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    public float dashDuration;
    public float dashSpeed;
    public bool isDashing;

    public Vector3 input;

    public bool sliding;
    public bool canMove;

    public EventInstance playerFootsteps;

    private void Start()
    {
        playerFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.playerFootsteps);

        rb = GetComponent<Rigidbody>();
        //   Bullet = GetComponent<Gun>();

        UpdateSound();
    }

    void Update()
    {
        if (!sliding && canMove)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            input = new Vector3(horizontalInput, 0, verticalInput).normalized;

            rb.velocity = new Vector3(input.z * playerSpeed, 0, -input.x * playerSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            StartCoroutine(Dash());
        }

          // Debug.Log(input.x);
    }

    private void FixedUpdate()
    {
        UpdateSound();
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        rb.velocity = new Vector3(input.x * dashSpeed, 0, input.z * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }

    private void OnTriggerExit(Collider other)
    {
        camTran = false;
    }

    private void UpdateSound()
    {
        playerFootsteps.set3DAttributes(RuntimeUtils.To3DAttributes(playerBottom.position));

        if (rb.velocity.x != 0f)
        {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);

            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                playerFootsteps.start();
        }
        else if (rb.velocity.z != 0f)
        {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);

            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                playerFootsteps.start();
        }
        else if (rb.velocity.z != 0f && rb.velocity.x != 0f)
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
