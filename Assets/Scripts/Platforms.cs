using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public Transform cam;
    public GameObject[] plataformasChindren;
    public int plataformaRandom = 0;

    // Start is called before the first frame update
    void Start()
    {
        plataformasChindren[plataformaRandom].SetActive(true);
        transform.position = new Vector3(Random.Range(1, 10), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < (cam.position.y - 10))
        {
            
            transform.position = new Vector3(transform.position.x, cam.position.y + 12, transform.position.z);
            transform.position = new Vector3(Random.Range(1, 10), transform.position.y, transform.position.z);

            plataformasChindren[plataformaRandom].SetActive(false);

            plataformaRandom = Random.Range(0, plataformasChindren.Length);
            plataformasChindren[plataformaRandom].SetActive(true);

        }
    }

    //TODO: añadir ObjectPooling
}
