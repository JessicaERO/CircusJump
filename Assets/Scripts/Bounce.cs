using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private SpriteRenderer sprite;
    private bool moved;


    private GameObject player;
    private BoxCollider2D miboxCollider2D;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        miboxCollider2D = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    //private void Update()
    //{
    //    if (!sprite.isVisible /*&& !moved*/)
    //    {
    //        transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
    //        moved = true;
    //    }
    //    //else
    //    //    moved = false;
    //}

    private void Update()
    {
        if((player.transform.position.y+0.5f )< transform.position.y)
        {
            miboxCollider2D.enabled = false;
        }
        else
        {
            miboxCollider2D.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 600f);
        }
    }
    //private void OnBecameInvisible()
    //{
    //    Debug.Log("bye");
    //    gameObject.SetActive(false);
    //    //transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
    //}
}
