using UnityEngine;

public class PlayerMovement : Portable
{
    public float speed;
    public float jumpVelocity;
    public float fallSpeedMultiplier;

    private bool jump;
    private float x_axis;

    private bool grounded;

    public override void BottomEnter(Collision2D collision)
    {
        base.BottomEnter(collision);

        grounded = true;
    }

    private void Update()
    {
        jump |= Input.GetButtonDown("Jump");
        x_axis = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (jump && grounded)
        {
            jump = false;
            grounded = false;
            SetVelocity(null, jumpVelocity);
        }

        if (rb.velocity.y < 0)
        {
            transform.position += new Vector3(0, rb.velocity.y) * (fallSpeedMultiplier - 1) * Time.fixedDeltaTime;
        }

        transform.position += new Vector3(x_axis, 0) * speed;
    }
}
