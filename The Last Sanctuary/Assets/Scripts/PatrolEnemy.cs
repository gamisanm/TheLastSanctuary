using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float speed;

    private bool movingRight = true;

    public Transform pointStart;
    public Transform pointStop;

    private void Update()
    {
        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointStop.position, speed * Time.deltaTime);

            if (transform.position == pointStop.position)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointStart.position, speed * Time.deltaTime);

            if (transform.position == pointStart.position)
            {
                movingRight = true;
            }
        }
    }
}
