using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public static Pickup instance;
    //Variable para comprobar si el item que hemos cogido es una gema o una cura
    public bool isCoin;
    //Variable para evitar que el mismo item se coja 2 veces
    private bool isCollected;

    ////Variable para guardar el objeto que queremos instanciar al coger un item
    //public GameObject pickUpEffect;
    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el objeto que ha colisionado con el item es el jugador y este item no ha sido cogido antes
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Me ah tocao");
            //Aumentamos en 1 la cantidad de monedas coleccionadas
            GameManager.instance.coin++;
            //Tras coger la gema el objeto se destruye
            Destroy(gameObject);
            ////Reproducimos el efecto de sonido que queremos 
            //AudioManager.instance.PlaySFX(0);
        }
    }
}
