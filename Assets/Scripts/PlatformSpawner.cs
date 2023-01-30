using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    //public GameObject[] platforms; //los distintos tipos de plataformas
    public Transform[] positions; 
    //public Vector2Int[] probabilities;

    public GameObject prefabFilas;

    GameObject platformPos;
    //GameObject playerPosition;
    //GameObject playerControllerPosition;
    //public GameObject platformSpawnerInicial;
    //public GameObject platformSpawnerActual;

    //void Start()
    //{
    //    platformPos.transform.position = Vector3.zero;
    //    platformSpawnerActual = Instantiate(prefabFilas, Vector3.zero, transform.rotation);
    //}

    void OnBecameInvisible()
    {
        if (!Pool.singleton.pooledItems[0].activeInHierarchy)
        {

        }
        //foreach(GameObject item in Pool.singleton.pooledItems)
        //{

        //}
    }
    //void OnBecameVisible()
    //{
    //    Pool.singleton.pooledItems[0].SetActive(true);
    //}

    //public void SpawnPlatform()
    //{
    //    int index = Random.Range(0, platformSpawnerActual.transform.childCount);
    //    foreach (Transform child in  platformSpawnerActual.transform)
    //    {
    //        Instantiate(platforms[0], child.position, transform.rotation);
    //    }
    //}

    public void RandomPlatform()
    {
        for (int i = 0; i < positions.Length; i++)
        {
            int typeOfPlatform = Random.Range(0, 100);
            platformPos.transform.position = new Vector3(typeOfPlatform, transform.position.y + 10, 0);

            int hasPlatform = Random.Range(0, 100);
            if (hasPlatform <= 10)
            {
                //Creamos una referencia a una plataforma que se pueda usar
                GameObject p = Pool.singleton.Get("Row");

                if (p != null)
                {
                    //La posición de la plataforma será aleatoria relativa al creador de asteroides
                    //p = (platforms[1], positions[i]);
                    p.transform.position = this.transform.position + new Vector3(Random.Range(-10, 10), 0, 0);
                    //Activamos la plataforma en concreto
                    p.SetActive(true);
                }
                //Instantiate(platforms[1], positions[i]);
                //si la probabilidad es verdadera se genera el tipo de plataforma 
            }
        }
    }
}
