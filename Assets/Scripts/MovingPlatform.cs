using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //la velocidad de la plataforma
    public float speed;
    //el punto inicial
    public int startingPoint;
    //un array de las posiciones en las que se mueve
    public Transform[] points;
    //el index del array
    private int i;

    void Start()
    {
        //esto posiciona la plataforma en uno de los points
        transform.position = points[startingPoint].position;
    }

    void Update()
    {
        //comprueba la distancia entre la plataforma y el point
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //sumale 1
            //comprueba si la plataforma estuvo en el último punto antes de que aumentara el index
            if (i == points.Length)
            {
                //resetea el index 
                i = 0;
            }
        }
        //mueve la plataforma a la posición del point con el index i
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
