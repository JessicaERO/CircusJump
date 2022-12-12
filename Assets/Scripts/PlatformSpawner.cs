using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platforms; //los distintos tipos de plataformas
    public Transform[] positions; 
    public Vector2Int[] probabilities;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Awake()
    {
        
        for (int i = 0; i < positions.Length; i++)
        {
            int typeOfPlatform = Random.Range(0, 100);
            //si el valor random que se genera es igual a uno que se encuentre dentro de las
            //probabilidades se genera el tipo de plataforma correspondiente
            //aqui iría el switch case
            int hasPlatform = Random.Range(0, 100);
            if (hasPlatform <= 10)
            {
                //Instantiate platforms[/*tipo de plataforma*/] posiciones[i]
                //si la probabilidad es verdadera se genera el tipo de plataforma 
            }
        }
    }
}
