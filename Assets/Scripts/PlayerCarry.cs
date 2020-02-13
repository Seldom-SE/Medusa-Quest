using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    public int maxOnTimer;

    private Collider2D coll;
    private GameObject isOn;
    private GameObject carrying;
    private float carryingHeight;
    private int onTimer;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (onTimer > 0)
        {
            if (carrying == null && Input.GetButtonDown("Fire1"))
            {
                carrying = isOn;
                isOn = null;
                carryingHeight = carrying.GetComponent<Collider2D>().bounds.extents.y;
                carrying.GetComponent<Collider2D>().enabled = false;
                carrying.GetComponent<Rigidbody2D>().simulated = false;
                onTimer = 0;
            }
            else
                onTimer--;
        }
        else
        {
            isOn = null;
        }

        if (carrying != null)
        {
            carrying.transform.position = new Vector3(transform.position.x, transform.position.y + coll.bounds.extents.y + carryingHeight);
        }
    }

    public void Ground(GameObject other)
    {
        isOn = other;
        onTimer = maxOnTimer;
    }
}
