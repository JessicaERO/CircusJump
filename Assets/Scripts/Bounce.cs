using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private SpriteRenderer sprite;
    private bool moved;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
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
