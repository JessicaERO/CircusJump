using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
    //privado
    private Rect _area;
    //accesor
    public Rect Area
    {
        //se obtiene la variable por referencia a la que queremos acceder 
        get { return _area; }
        //poner el valor de esa variable o referencia al usar el accesor
        set { _area = value; }
    }

    //referencia con su accesor para el GameArea principal
    private static GameArea _main;
    public static GameArea Main
    {
        get
        {
            //Si esta referencia esta vacia
            if (_main == null)
            {
                //La busco en la escena y la relleno
                _main = FindObjectOfType<GameArea>();
                //Pero si no hay una que recoger de la escena
                if (_main == null)
                {
                    //Creo un objeto con los componentes necesarios para que me permita rellenar
                    GameObject go = new GameObject("Game Area");
                    _main = go.AddComponent<GameArea>();
                    go.AddComponent<FitAreaToCamera>();
                }
            }
            return _main;
        }
        set
        {
            _main = value;
        }
    }

    //Tamaño del area
    private Vector2 _size;

    public Color gizmoColor = new Color(0, 0, 1, 0.2f);
    public Color gizmoWireColor = new Color(0, 0, 1, 0.2f);

    private void Awake()
    {
        SetArea(_size);
    }

    //Metodo para generar el area
    public void SetArea(Vector2 size)
    {
        Area = new Rect(size.x * -0.5f, size.y * -0.5f, size.x, size.y);
    }
    private void OnDrawGizmos()
    {

        //Asignamos el gizmo al objeto
        Gizmos.matrix = transform.localToWorldMatrix;
        //Dibujamos el gizmo de color xxxx
        Gizmos.color = gizmoColor;
        //Dibujamos el area
        Gizmos.DrawCube(Vector3.zero, new Vector3(Area.width, Area.height, 0));
        //Dibujamos el gizmo de color xxxx
        Gizmos.color = gizmoWireColor;
        //Dibujamos Aristas
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(Area.width, Area.height, 0));

    }

    //Accesor a el tamaño y posición del área
    public Vector2 Size
    {
        //Obtenemos la referencia de tamaño del área
        get { return Area.size; }
        //Ponemos el tamaño del área
        set
        {
            _size = value;
            //Posición inicial en X e Y, ancho y alto
            Area = new Rect(value.x * -0.5f, value.y * -0.5f, value.x, value.y);
        }
    }
    private void OnValidate()
    {
        SetArea(_size);
    }
    //es un metodo que nos devuelve una posicion aleatoria dentro del área de juego
    public Vector3 GetRandomPosition()
    {
        Vector3 randomPos = Vector3.zero;
        randomPos.x = Random.Range(Area.xMin, Area.xMax);
        randomPos.y = Random.Range(Area.yMin, Area.yMax);
        //convertimos esas coordenadas locales obtenidas dentro del area establecida, globales respecto al editor de unity
        randomPos = transform.TransformPoint(randomPos);
        return randomPos;
    }
}
