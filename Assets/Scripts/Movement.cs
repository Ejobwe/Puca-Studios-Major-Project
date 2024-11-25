using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;

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

<<<<<<< HEAD
<<<<<<< HEAD
            rb.linearVelocity = new Vector3(input.x * playerSpeed, 0, input.z * playerSpeed);
=======
            rb.velocity = new Vector3(input.x * playerSpeed, 0, input.z * playerSpeed);
>>>>>>> parent of 076a66e (Merge branch 'main' of https://github.com/Ejobwe/Puca-Studios-Major-Project)
=======
            rb.velocity = new Vector3(input.x * playerSpeed, 0, input.z * playerSpeed);
>>>>>>> parent of 076a66e (Merge branch 'main' of https://github.com/Ejobwe/Puca-Studios-Major-Project)
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
        rb.linearVelocity = new Vector3(input.x * dashSpeed, 0, input.z * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }

    
}
