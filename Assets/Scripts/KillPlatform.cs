using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si es el jugador el que entra en el trigger
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
