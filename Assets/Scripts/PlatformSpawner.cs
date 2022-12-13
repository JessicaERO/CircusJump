using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platforms; //los distintos tipos de plataformas
    public Transform[] positions; 
    public Vector2Int[] probabilities;

    GameObject platformPos;
    GameObject playerPosition;
    int playerControllerPosition;

    void Start()
    {
        platformPos.transform.position = Vector3.zero;
        Instantiate(platforms[], platformPos, transform.rotation);
    }

    void Update()
    {
        if (playerPosition = playerControllerPosition + 10)
        {

            for (int i = 0; i < positions.Length; i++)
            {
                int typeOfPlatform = Random.Range(0, 100);
                platformPos.transform.position = new Vector3(typeOfPlatform, transform.position.y + 10, 0);
                
                //si el valor random que se genera es igual a uno que se encuentre dentro de las
                //probabilidades se genera el tipo de plataforma correspondiente
                //aqui iría el switch case

                int hasPlatform = Random.Range(0, 100);
                if (hasPlatform <= 10)
                {
                    Instantiate(platforms[1], positions[i]);
                    //si la probabilidad es verdadera se genera el tipo de plataforma 
                }

                switch (hasPlatform)
                {
                    case 1:
                        hasPlatform < 20
                        {
                            //to do:
                            //instanciamos la plataforma 
                            Instantiate(platforms[1], positions[i]);
                            platformPos = Instantiate(platforms, new Vector3(0, , 0), transform.rotation);
                        }
                        break;

                    case 2:
                        hasPlatform > 20 && < 40
                        {
                            //to do:
                            //instanciamos la plataforma 
                            Instantiate(platforms, new Vector3(2.5f,  , 0), transform.rotation);
                        }
                        break;
                }

            }
        }
    }

}
