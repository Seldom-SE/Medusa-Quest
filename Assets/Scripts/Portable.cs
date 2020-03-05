using UnityEngine;

public class Portable : MonoBehaviour
{
    public void BottomEnter(Collision2D collision)
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
}
