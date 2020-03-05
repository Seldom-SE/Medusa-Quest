using UnityEngine;

public class PortableBottom : MonoBehaviour
{
    public Portable parent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        parent.BottomEnter(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        parent.BottomExit(collision);
    }
}
