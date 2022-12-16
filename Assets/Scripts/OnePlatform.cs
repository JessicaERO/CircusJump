using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnePlatform : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el upToDown en el código de player cotroller esta activado
        if (PlayerController.instance.upToDown == true)
        {
            //Desactivamos esta plataforma
            this.gameObject.SetActive(false);
        }
    }
}
