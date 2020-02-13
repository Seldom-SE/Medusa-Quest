using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    private PlayerMove parentMove;

    private void Start()
    {
        parentMove = transform.parent.GetComponent<PlayerMove>();
    }

    public void OnTriggerStay2D(Collider2D _)
    {
        // Tell parent it's on ground
        parentMove.Ground();
    }
}
