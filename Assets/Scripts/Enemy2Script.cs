using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool movingRight = true;

    private float frames;

    public Transform wallDetection;

    void Start()
    {
        frames = Time.frameCount;
    }

    void turning()
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

    void Update()
    {
        frames = Time.frameCount;

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, distance);
        if (wallInfo.collider == true)
        {
            turning();
        }

        if (frames % 180 == 0)
        {
            turning();
        }
    }
}

