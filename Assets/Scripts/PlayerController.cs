using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;

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

    public GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    public DatabaseManager dataManager;

    private void Awake()
    {
        instance = this;
        currentScene = SceneManager.GetActiveScene();
        scene = currentScene.ToString();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //[System.Obsolete]
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        if (Application.loadedLevelName == "InfiniteGame")
        {
            Debug.Log("estoy entrando aqui?");
            //if (PlayerPrefs.HasKey("Highscore"))
            //{
            //    highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore");
            //}
            if (PlayerPrefs.HasKey("Highscore"))
            {
                highscoreText.text = "HIGHSCORE: " + DataBaseManager.LoadHighscore();
            }
        }

        spriteRenderer.sprite = gameManager.skins[PlayerPrefs.GetInt("selectedSkinIndex", 0)];
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
                // Guardar monedas acumuladas.
                gameManager.SaveCoins();
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
            //if (score > PlayerPrefs.GetInt("Highscore"))
            //{
            //    //PlayerPrefs.SetInt("Highscore", score);
            //    dataManager.InsertarPuntos(score);
            //}      
            if (score > DataBaseManager.LoadHighscore())
            {
                DataBaseManager.SaveHighscore(score);
            }           
        }
    }

    public class PlayerData
    {
        public Vector3 position;

        //Constructor de la clase
        public PlayerData(Transform transform)
        {
            //Rellenamos las variables con las que le pasamos por parámetro
            position = transform.position;
        }
    }

    //Crearemos un objeto serializable capaz de ser guardado
    public JObject Serialize()
    {
        //Instanciamos la clase anidada pasándole por parámetro las variables que queremos guardar
        PlayerData data = new PlayerData(transform);

        //Creamos un string que guardará el jSon
        string jsonString = JsonUtility.ToJson(data);
        //Creamos un objeto en el jSon
        JObject retVal = JObject.Parse(jsonString);
        //Al ser un método de tipo, debe devolver este tipo
        return retVal;
    }

    //Tendremos que deserializar la información recibida
    public void Deserialize(string jsonString)
    {
        PlayerData data = new PlayerData(transform);
        //La información recibida del archivo de guardado sobreescribirá los campos oportunos del jsonString
        JsonUtility.FromJsonOverwrite(jsonString, data);

        // Actualizamos los datos del enemigo con los datos del archivo de guardado
        transform.position = data.position;
    }
}
