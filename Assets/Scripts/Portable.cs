using UnityEngine;

public class Portable : MonoBehaviour
{
    protected Rigidbody2D rb;

    public virtual void BottomEnter(Collision2D collision)
    {
        if (transform.parent == null && collision.gameObject.GetComponent<Portable>() != null)
        {
            transform.parent = collision.transform;
        }
    }

    public void BottomExit(Collision2D collision)
    {
        if (collision.transform == transform.parent)
        {
            transform.parent = null;
        }
    }

    // Parameters take null when the velocity is not to change
    public void SetVelocity(float? x, float? y)
    {
        if (x is float xValue)
        {
            rb.velocity = new Vector2(xValue, rb.velocity.y);
        }

        if (y is float yValue)
        {
            rb.velocity = new Vector2(rb.velocity.x, yValue);
        }

        foreach (Transform child in transform)
        {
            Portable portable = child.GetComponent<Portable>();
            if (portable != null)
            {
                portable.SetVelocity(x, y);
            }
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
