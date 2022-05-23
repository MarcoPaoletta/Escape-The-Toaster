using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour
{
    public Canvas gameOverScreen;
    public Canvas hud; 
    public Rigidbody2D rb;
    public static bool isAlive = true; 
    public static bool started;

    private int speed = 4;
    private float horizontal;

    void Start()
    {
        SetVariables();
    }

    void SetVariables()
    {
        isAlive = true;
        started = false;
    }

    void Update()
    {
        StartGame();

        if(started)
        {
            HorizontalMovement();
            CheckHealthState();
        }
    }

    void StartGame()
    {
        if(Input.GetMouseButtonDown(0) && !Menu.buttonPressed)
        {
            started = true;
            hud.gameObject.SetActive(true);
            GameObject.Find("Menu").SetActive(false);
            GameObject.Find("GameManager").GetComponent<GameManager>().SpawnInitialClouds();
        }
        if(started)
        {
            rb.gravityScale = -20;
        }
    }

    void HorizontalMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed; 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.65f, 2.65f), transform.position.y, transform.position.z);
    }

    void CheckHealthState()
    {
        if(!isAlive)
        {
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, 0); 
    }

    void OnTriggerEnter2D(Collider2D body)
    {
        if(body.CompareTag("Toaster"))
        {
            Death();
        }
        if(body.CompareTag("Money"))
        {
            Destroy(body.gameObject);
            hud.GetComponent<HUD>().Money();
        }
    }

    void Death()
    {
        Time.timeScale = 0; // pause the game
        isAlive = false;
        gameOverScreen.gameObject.SetActive(true);
        hud.gameObject.SetActive(false);
    }
}
