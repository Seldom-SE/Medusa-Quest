using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpVelocity;
    public int coyoteTime;

    private int groundedTimer;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Horiontal movement
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0) * speed;

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
}
