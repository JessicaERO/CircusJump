using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase para referenciar a los objetos del pool
[System.Serializable] //Podremos a�adir estos objetos a trav�s del inspector
public class PoolItem
{
    //Objeto para meter en el pool
    public GameObject prefab;
    //Cantidad del objeto
    public int amount;
    //Variable para controlar si el pool se puede hacer m�s grande para este tipo de objeto
    public bool expandable;
}

public class Pool : MonoBehaviour
{
    //Una referencia a una lista de objetos sobre los que vamos a usar el Pool
    public List<PoolItem> items;
    //Una referencia a una lista de GO
    public List<GameObject> pooledItems;

    //Para sacar la informaci�n del Pool
    public static Pool singleton;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la lista
        pooledItems = new List<GameObject>();
        //Recorremos la lista de objetos sobre los que se puede hacer el Pool
        foreach (PoolItem item in items)
        {
            float aux = 2.5f;
            //Hacemos un bucle para la cantidad del objeto sobre el que hacemos el Pool
            for (int i = 0; i < item.amount; i++)
            {
                //Referenciamos el objeto instanciado
                GameObject obj = Instantiate(item.prefab);
                //Desactivamos el objeto
                obj.SetActive(true);               
                obj.transform.position = new Vector3(transform.position.x, 0 + aux, transform.position.z);
                aux += 2.5f;
                pooledItems.Add(obj);
                //GameObject obj = GameObject.FindGameObjectsWithTag("Row");
                //Lo a�adimos a la lista de objetos que van a ser reutilizados
                //pooledItems.Add(GameObject.FindGameObjectsWithTag("Row")[i]);
            }
        }
    }

    //M�todo que nos devuelve un GameObject pas�ndole una etiqueta por par�metro (nos devuelve un objeto de un tipo que sea reutilizable)
    public GameObject Get(string tag)
    {
        //Hacemos una pasada por la lista de objetos reutilizables
        for (int i = 0; i < pooledItems.Count; i++)
        {
            //Si el objeto concreto no est� activo en la jerarqu�a y adem�s su etiqueta coincide con la pasada por par�metro
            if (!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
            {
                //Devolvemos ese objeto concreto
                return pooledItems[i];
            }
        }

        //Hacemos una pasada por toda la lista de tipos de objetos del pool
        foreach (PoolItem item in items)
        {
            //Si la etiqueta del objeto que buscamos coincide con la del tipo de objeto sobre el que queremos trabajar, y es ampliable en el Pool
            if (item.prefab.tag == tag && item.expandable)
            {
                //Instaciamos un nuevo objeto de ese tipo
                GameObject obj = Instantiate(item.prefab);
                //Desactivamos ese objeto en concreto con la finalidad de que pueda ser reutilizado
                obj.SetActive(false);
                //A�adimos ese objeto en concreto a la lista de objetos reutilizables
                pooledItems.Add(obj);
                //Nos devuelve este objeto en concreto para ser utilizado
                return obj;
            }
        }

        //De lo contrario nos devuelve una referencia vac�a
        return null;
    }
}
