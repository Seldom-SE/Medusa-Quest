using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    private PlayerMove parentMove;
    private PlayerCarry parentCarry;

    private void Start()
    {
        parentMove = transform.parent.GetComponent<PlayerMove>();
        parentCarry = transform.parent.GetComponent<PlayerCarry>();
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        // Tell parent it's on ground
        parentMove.Ground();

        // Check whether it is portable
        if (collider.GetComponent<Portable>() != null)
            parentCarry.Ground(collider.gameObject);
    }
}
