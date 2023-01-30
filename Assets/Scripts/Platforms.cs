using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public Transform cam;
    public GameObject[] plataformasChindren;
    private int plataformaRandom = 0;

    //private void OnBecameInvisible()
    //{
    //    //Debug.Log("bye");
    //    //gameObject.SetActive(false);
    //    //transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        
        
    //}

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

            //plataformasChindren[plataformaRandom].SetActive(false);

            plataformaRandom = Random.Range(0, plataformasChindren.Length);
            //plataformasChindren[plataformaRandom].SetActive(true);

        }
    }

    /// <summary>
    /// Cambia el tipo de plataforma
    /// </summary>
    public void ChangeTypePlatform()
    {
        //desactiva la plataforma actual
        plataformasChindren[plataformaRandom].SetActive(false);
        //actualiza el indice
        //plataformaRandom = Random.Range(0, plataformasChindren.Length);
        //activa uno de los hijos de este objeto al azar
        plataformasChindren[plataformaRandom].SetActive(true);
    }
}
