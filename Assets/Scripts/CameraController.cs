using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Hacemos un Singleton del script. Es decir, hacemos que solamente pueda haber un script de este tipo. Podremos acceder con esta instance a este script desde cualquier lugar
    public static CameraController instance;

    //Variable de tipo transform para que la cámara pueda seguir una posición
    public Transform target;
    ////Variables para control Parallax
    //public Transform farBackground, middleBackground;
    //Variable para hacer un seguimiento del movimiento, nos dará la última posición en el eje X y en el eje Y en la que estábamos
    private Vector2 lastPos;
    //Variables para controlar la altura mínima y máxima que la cámara puede alcanzar
    //public float minHeight, maxHeight;
    //Variables para controlar la altura mínima y máxima que la cámara puede alcanzar
    public float maxLeft, maxRight;

    //Variable para controlar si la cámara sigue o no al jugador
    public bool stopFollow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Esta línea equivale a todo lo comentado arriba
       // transform.position = new Vector3(Mathf.Clamp(target.position.x, maxLeft, maxRight), target.position.y, transform.position.z);

        //Cantidad de movimiento en X y en Y que debe hacer la cámara
       // Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        ////Las nubes se mueven conforme a la cámara
        //farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        ////Los arboles se mueven a la mitad de velocidad de la cámara
        //middleBackground.position += new Vector3(amountToMove.x * .5f, amountToMove.y * .5f, 0f);
        ////Actualizamos la última posición
        //lastPos = transform.position;



        if(transform.position.y < (target.position.y))
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
    }
}
