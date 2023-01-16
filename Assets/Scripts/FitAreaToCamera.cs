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
        //Con esto ajustamos la nueva área al ancho y alto de visión de la cámara para ese dispositivo concreto
        Area.Size = new Vector2(cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2);
        //Movemos ese área con respecto a la posición y rotación de la cámara
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 0);
        transform.rotation = cam.transform.rotation;
    }

    private void FitToMainCamera()
    {
        //Creamos el área en base a la cámara principal de la escena
        FitToCamera(Camera.main);
    }

    //Es un método que solo se llama para el editor, o cuando hay cambios en el editor en una variable
    private void OnValidate()
    {
        FitToMainCamera();
    }

    //Cuando pulsemos en el botón de Reset en el editor de Unity en este componente se reiniciará el área
    private void Reset()
    {
        FitToMainCamera();
    }
}
