using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    public int maxOnTimer;
    public float throwVelocity;

    private PlayerMove move;
    private Collider2D coll;
    private Rigidbody2D rb;

    private GameObject isOn;
    private int onTimer;

    private GameObject carrying;
    private Collider2D carryingColl;
    private Rigidbody2D carryingRb;

    private void Start()
    {
        move = GetComponent<PlayerMove>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (carrying != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // Throw
                carrying.transform.parent = null;
                carryingColl.enabled = true;
                carryingRb.simulated = true;
                carryingRb.velocity = rb.velocity + new Vector2((move.GetFacingRight() ? 1 : -1) * throwVelocity, 0);
                carrying = null;
            }
        }

        if (onTimer > 0)
        {
            if (carrying == null && Input.GetButtonDown("Fire1"))
            {
                // Pick up
                carrying = isOn;
                isOn = null;
                carrying.transform.parent = transform;
                carryingColl = carrying.GetComponent<Collider2D>();
                carryingRb = carrying.GetComponent<Rigidbody2D>();
                carrying.transform.position = new Vector3(transform.position.x, transform.position.y + coll.bounds.extents.y + carryingColl.bounds.extents.y);
                carryingColl.enabled = false;
                carryingRb.simulated = false;
                onTimer = 0;
            }
            else
                onTimer--;
        }
        else
        {
            isOn = null;
        }
    }

    public void Ground(GameObject other)
    {
        isOn = other;
        onTimer = maxOnTimer;
    }
}
