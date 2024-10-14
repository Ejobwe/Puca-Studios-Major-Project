using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    public float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    public float dashDuration;
    public float dashSpeed;
    public bool isDashing;

    private Vector3 input;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //   Bullet = GetComponent<Gun>();
    }

    void Update()
    {
     
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        input = new Vector3(horizontalInput, 0, verticalInput).normalized;

        rb.linearVelocity = new Vector3(input.x * playerSpeed, 0, input.z * playerSpeed);
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            StartCoroutine(Dash());
        }

        //   Debug.Log(rb.velocity);
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        rb.linearVelocity = new Vector3(input.x * dashSpeed, 0, input.z * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }

    
}
