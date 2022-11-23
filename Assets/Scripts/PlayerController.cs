using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D theRB;
    private float moveInput;
    private float speed = 10f;

    private float topScore = 0.0f;
    public Text scoreText;

    //Se hace un Singleton del script
    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (moveInput < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (theRB.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal") + Input.acceleration.x;
        theRB.velocity = new Vector2(moveInput * speed, theRB.velocity.y);
    }
}
