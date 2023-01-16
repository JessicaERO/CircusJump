using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitAreaToCamera : MonoBehaviour
{
    private void Awake()
    {
        FitToMainCamera();
    }
    private GameArea Area
    {
        get { return GetComponent<GameArea>(); }
    }
    private void FitToCamera(Camera cam)
    {
        //Con esto ajustamos la nueva �rea al ancho y alto de visi�n de la c�mara para ese dispositivo concreto
        Area.Size = new Vector2(cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2);
        //Movemos ese �rea con respecto a la posici�n y rotaci�n de la c�mara
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 0);
        transform.rotation = cam.transform.rotation;
    }

    private void FitToMainCamera()
    {
        //Creamos el �rea en base a la c�mara principal de la escena
        FitToCamera(Camera.main);
    }

    //Es un m�todo que solo se llama para el editor, o cuando hay cambios en el editor en una variable
    private void OnValidate()
    {
        FitToMainCamera();
    }

    //Cuando pulsemos en el bot�n de Reset en el editor de Unity en este componente se reiniciar� el �rea
    private void Reset()
    {
        FitToMainCamera();
    }
}
