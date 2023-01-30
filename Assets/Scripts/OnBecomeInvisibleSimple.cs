using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBecomeInvisibleSimple : MonoBehaviour
{
    public Platforms platforms;

    // Start is called before the first frame update
    void Start()
    {
        //si no está asignado...
        if (!platforms)
        {
            //busca el objeto que tiene asociado el scrip de Platform en el padre
            platforms = transform.parent.gameObject.GetComponent<Platforms>();
        }
    }
    private void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
            platforms.ChangeTypePlatform();
    }

}
