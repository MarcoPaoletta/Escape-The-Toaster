using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    public Rigidbody2D rb;

    private int speed;

    void Start()
    {
        SetInitialSpeed();
        InvokeRepeating("CheckLimits", 0.1f, 0.1f);
    }

    void SetInitialSpeed()
    {
        int randomNumber = Random.Range(0, 1);
        int randomSpeed = Random.Range(3, 6);

        if(randomNumber == 0)
        {
            speed = randomSpeed;
        }
        else
        {
            speed = -randomSpeed;
        }
    }

    void CheckLimits()
    {
        if(transform.position.x < -2.2f || transform.position.x > 2.2f)
        {
            speed *= -1;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
