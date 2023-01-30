using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnePlatform : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D theCollider;

    private void OnEnable()
    {
        //if(!theCollider)
        //    theCollider.enabled = true;
        //if(!spriteRenderer)
        //    spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
    }
    private void Start()
    {
        theCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el upToDown en el código de player cotroller esta activado
        if (PlayerController.instance.upToDown == true)
        {
            //Desactivamos esta plataforma
            this.gameObject.SetActive(false);
            //theCollider.enabled = false;
            //spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.25f);
        }
    }
}
