using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpVelocity;
    public int coyoteTime;

    private int groundedTimer;
    private Rigidbody2D rb;
    private bool facingRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Horiontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.01)
            facingRight = true;
        else if (horizontalInput < 0.01)
            facingRight = false;
        transform.position += new Vector3(horizontalInput * speed, 0);

        // Jumping
        if (groundedTimer > 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                // Jump
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
                groundedTimer = 0;
            }
            else
                groundedTimer--;
        }
    }

    public void Ground()
    {
        groundedTimer = coyoteTime;
    }

    public bool GetFacingRight()
    {
        return facingRight;
    }
}
