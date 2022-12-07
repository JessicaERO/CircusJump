using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    public GameObject hurtPrefab;
    //public GameObject coinPlatPrefab;
    //public GameObject movePlatPrefab;
    private GameObject myPlatform;
    public float prob1, prob3, prob5;
    int controller = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            int x = Random.Range(1, 100);
            //PLATAFORMA DEFAULT
            if (x > 0 && x <= prob1)
            {
                Destroy(collision.gameObject);
                controller--;
                if (controller < 10)
                {
                    Instantiate(platformPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (6 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
                    controller++;
                }
            }
            ////PLATAFORMA + MONEDA
            //else if (x > prob1 && x <= prob2)
            //{
            //    Destroy(collision.gameObject);
            //    controller--;

            //    if (controller < 10)
            //    {
            //        Instantiate(coinPlatPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (6 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
            //        controller++;
            //    }
            //}
            //PLATAFORMA DE SALTO
            else if (x > prob1 && x <= prob3)
            {
                Destroy(collision.gameObject);
                controller--;

                if (controller < 10)
                {
                    Instantiate(springPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (6 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
                    controller++;
                }
            }
            ////PLATAFORMA EN MOVIMIENTO
            //else if (x > prob3 && x <= prob4)
            //{
            //    Destroy(collision.gameObject);
            //    controller--;

            //    if (controller < 10)
            //    {
            //        Instantiate(movePlatPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
            //        controller++;
            //    }
            //}
            //PLATAFORMA DE MUERTE
            else if (x > prob3 && x <= prob5)
            {
                Destroy(collision.gameObject);
                controller--;

                if (controller < 10)
                {
                    Instantiate(hurtPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
                    controller++;
                }
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
