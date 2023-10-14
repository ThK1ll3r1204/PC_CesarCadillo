using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    public float speed = 5f;
    public Vector3 leftPoint;
    public Vector3 rightPoint;
    private bool movingRight = true;

    void Update()
    {        
        Move();
    }

    void Move()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x > rightPoint.x)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < leftPoint.x)
                movingRight = true;
        }
    }

    

}
