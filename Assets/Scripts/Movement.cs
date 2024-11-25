using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;

    public bool camTran;

    public float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    public float dashDuration;
    public float dashSpeed;
    public bool isDashing;

    public Vector3 input;

    public bool sliding;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //   Bullet = GetComponent<Gun>();
    }

    void Update()
    {
        if (!sliding)
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
}
