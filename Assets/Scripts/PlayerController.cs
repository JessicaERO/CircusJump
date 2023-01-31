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

    public int score = 0;
    public Text scoreText;
    public Text highscoreText;

    public float time, timeMax;
    public bool isDead;

    public bool upToDown;

    Scene currentScene;
    string scene;

    private void Awake()
    {
        instance = this;
        currentScene = SceneManager.GetActiveScene();
        scene = currentScene.ToString();
    }

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        if (scene == "InfiniteGame")
        {
            if (PlayerPrefs.HasKey("Highscore"))
            {
                highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
            }
        }
        
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
            score = (int)transform.position.y;
        }
        scoreText.text = "SCORE: " + Mathf.Round(score).ToString();

        if (isDead)
        {
            time = time + Time.deltaTime;
            if (time >= timeMax)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        //Cuando la velocidad es <= que 0 (osea, cuando el jugado está bajando)
        if (theRB.velocity.y <= 0)
            upToDown = true;
        
        else
            upToDown = false;
        
    }

    void FixedUpdate()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        moveInput = Input.GetAxis("Horizontal") + Input.acceleration.x * 2f;
        theRB.velocity = new Vector2(moveInput * speed, theRB.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathLane"))
        {
            isDead = true;
            if (PlayerPrefs.HasKey("CoinsAmount"))
            {
                //Obtenemos el total de las monedas ganadas
                GameManager.instance.totalCoins = PlayerPrefs.GetInt("CoinsAmount");
                //Le sumamos las monedas obtenidas en esta partida
                GameManager.instance.totalCoins += GameManager.instance.coin;
                //Actualizamos el total de monedas ganadas guardadas
                PlayerPrefs.SetInt("CoinsAmount", GameManager.instance.totalCoins);
            }
            if (score>PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", score);
            }           
        }
    }
}
