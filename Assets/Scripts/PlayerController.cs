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

    //public Transform[] filas;
    //public Transform filaInicial;
    //public PlatformSpawner platformSpawnerInicial;
    //public PlatformSpawner platformSpawnerActual;
    //variable transform que guarde la fila actual

    //el PlatformSpawner debe ser el que está por debajo de la pantalla
    //si el player esta en la fila 1, sube la fila 0 a la posición 7 + la altura que haya entre filas 
    //tras hacer esto llama a la función de borrar plataformas y crear plataformas

    //para subirle la dificultad, por cada ciclo que suba, aumenta la dificultad con una variable
    //el PlatformSpawner se sustituye por el de la fila en la que estaba

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
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
        //si la altura es mayor que la de la fila actual, llamo a la funcion destruirPlataformas del PlatformSpawner y a la RandomSpawner
        //en ese orden

        //ESTO ES PARA REFERENCIAR EN EL SCRIRPT ONEPLATFORM Y ASI ELIMINARLO
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
