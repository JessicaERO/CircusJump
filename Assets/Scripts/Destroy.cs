using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    public GameObject hurtPrefab;
    public GameObject coinPlatPrefab;
    private GameObject myPlatform;
    public float prob1, prob2, prob3, prob4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            int x = Random.Range(0, 100);
            if(x>0 && x <= prob1)
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
                
            }
            if (x > prob1 && x <= prob2)
            {
                Destroy(collision.gameObject);
                Instantiate(coinPlatPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f))), Quaternion.identity);

            }
            if (x>prob2 && x <= prob3)
            {
                Destroy(collision.gameObject);
                Instantiate(springPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
            }
            if(x>prob3 && x <= prob4)
            {
                Destroy(collision.gameObject);
                Instantiate(hurtPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
            }

        }

        //if (collision.gameObject.name.StartsWith("Platform"))
        //{
        //    if (Random.Range(1, 7) == 1)
        //    {
        //        Destroy(collision.gameObject);
        //        Instantiate(hurtPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f))), Quaternion.identity);

        //    }
        //    else if (Random.Range(1, 7) == 1)
        //    {
        //        Destroy(collision.gameObject);
        //        Instantiate(springPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f))), Quaternion.identity);

        //    }
        //    else
        //    {
        //        collision.gameObject.transform.position = new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f)));

        //    }
        //}
        //else if (collision.gameObject.name.StartsWith("Platform"))
        //{
        //    if (Random.Range(1, 7) == 1)
        //    {
        //        Destroy(collision.gameObject);
        //        Instantiate(hurtPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
        //        Debug.Log("Estoy aqui 1");
        //    }
        //    else
        //    {
        //        collision.gameObject.transform.position = new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f)));
        //        Debug.Log("Estoy aqui 2");
        //    }
        //}
        //if (collision.gameObject.name.StartsWith("Hurt"))
        //{
        //    if (Random.Range(1, 7) == 1)
        //    {
        //        collision.gameObject.transform.position = new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f)));
        //        Debug.Log("Estoy aqui 1");
        //    }
        //    else
        //    {
        //        Destroy(collision.gameObject);
        //        Instantiate(hurtPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
        //        Debug.Log("Estoy aqui 2");
        //    }
        //}
        //else if (collision.gameObject.name.StartsWith("Spring"))
        //{
        //    if (Random.Range(1, 7) == 1)
        //    {
        //        collision.gameObject.transform.position = new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f)));
        //    }
        //    else
        //    {
        //        Destroy(collision.gameObject);
        //        Instantiate(platformPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (8 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
        //        Debug.Log("Estoy aqui 3");
        //    }
        //}
        

        //if (Random.Range(1, 6) > 1)
        //{
        //    myPlatform = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (8 + Random.Range(0.5f, 1f))), Quaternion.identity);
        //}
        //else
        //{
        //    myPlatform = (GameObject)Instantiate(springPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (8 + Random.Range(0.5f, 1f))), Quaternion.identity);
        //}

        //Destroy(collision.gameObject);
    }
}
