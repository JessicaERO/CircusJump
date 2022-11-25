using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Rigidbody2D theRB;
    private float moveInput;
    private float speed = 10f;

    public float score = 0.0f;
    public Text scoreText;

    public float time, timeMax;
    public bool isDead;

    private void Awake()
    {
        instance = this;
    }

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

        if (theRB.velocity.y > 0 && transform.position.y > score)
        {
            score = transform.position.y;
        }
        scoreText.text = "Score: " + Mathf.Round(score).ToString();

        if (isDead)
        {
            time = time + Time.deltaTime;
            if(time >= timeMax)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void FixedUpdate()
    {
        Debug.Log(Input.GetAxis("Horizontal"));
        moveInput = Input.GetAxis("Horizontal") + Input.acceleration.x * 2f;
        theRB.velocity = new Vector2(moveInput * speed, theRB.velocity.y);
    }

    private void OnBecameInvisible()
    {
        
        isDead = true;
    }
}
