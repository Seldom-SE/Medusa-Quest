using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : MonoBehaviour
{
    public float speed;
    public float distance;

    // Change from 'right' to 'left' if the enemy should start going left
    private bool movingRight = true;

    public Transform wallDetection;

    // Update is called once per frame
    void Update()
    {
        // Change from 'right' to 'left' if the enemy should start going left
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, distance);
        if (wallInfo.collider == true)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                distance *= -1;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
                distance *= -1;
            }
        }
    }
}
