using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaKeeper : MonoBehaviour
{
    //Referencia a la clase Game Area
    public GameArea gameArea;
    //Referencia para guardar la posicion del player
    public Vector2 areaSpacePosition;
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
}
