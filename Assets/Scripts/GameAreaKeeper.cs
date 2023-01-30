using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaKeeper : MonoBehaviour
{
    //Referencia a la clase Game Area
    public GameArea gameArea;
    //Referencia para guardar la posicion del player
    public Vector2 areaSpacePosition;

    public bool isPlatform;

    private void Start()
    {
        if (!gameArea)
            gameArea = GameArea.Main;
        
    }
    private void FixedUpdate()
    {
        //Alteramos la posicion del player al llegar a los limites
        areaSpacePosition = gameArea.transform.InverseTransformPoint(transform.position);

        if (gameArea.Area.Contains(areaSpacePosition))
        {
            //Salir del bucle Update
            return;
        }
        //si no es plataforma...
        if (!isPlatform)
        {
            if (areaSpacePosition.x < gameArea.Area.xMin)
            {
                areaSpacePosition.x = gameArea.Area.xMax;
            }
            else if (areaSpacePosition.x > gameArea.Area.xMax)
            {
                areaSpacePosition.x = gameArea.Area.xMin;
            }
            //Movemos al player a esa posicion
            transform.position = gameArea.transform.TransformPoint(areaSpacePosition);
        }
        //de lo contrario...
        else
        {
            if (areaSpacePosition.y < gameArea.Area.yMin)
            {
                areaSpacePosition.y = gameArea.Area.yMax;
            }
            //else if (areaSpacePosition.y > gameArea.Area.yMax)
            //{
            //    areaSpacePosition.y = gameArea.Area.yMin;
            //}
            //Movemos la plataforma a esa posicion
            transform.parent.position = gameArea.transform.TransformPoint(areaSpacePosition);
        }

        
    }
}
