using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    //Variables de tipo Punto de mapa para guardar posiciones a las que podemos ir desde otros puntos del mapa
    public MapPoint up, down;
    //Variable para saber si en ese punto del mapa hay un nivel y si está bloqueado o no
    public bool isLevel, isLocked;

    //Variable para saber que nivel hay que cargar y pasar saber que nivel hay que chequear para saber si está bloqueado o no, y el nombre del nivel
    public string levelToLoad, levelToCheck, levelName;

    //Variables para saber las gemas cogidas y el total de gemas, se guarda para las monedas
    //public int gemCollected, totalGems; 
    //Variables para saber el mejor tiempo y el tiempo asignado al nivel
    //public float bestTime, targetTime;

    //Variables para las medallas del nivel
    //public GameObject gemBadge, timeBadge;

    // Start is called before the first frame update
    void Start()
    {
        //Queremos comprobar y poner si el nivel actual está bloqueado o no
        //Si el punto del mapa es un nivel, y hay un nivel que cargar
        if (isLevel && levelToLoad != null)
        {
            //Si existe en el archivo de guardado una Key que sea el nombre del nivel a cargar + un número de gems
            /*if (PlayerPrefs.HasKey(levelToLoad + "_gems"))
            {
                //Obtenemos las gemas recogidas en ese nivel
                gemCollected = PlayerPrefs.GetInt(levelToLoad + "_gems");
            }*/

            //Si existe en el archivo de guardado una Key que sea el nombre del nivel a cargar + un número de tiempo
            /*if (PlayerPrefs.HasKey(levelToLoad + "_time"))
            {
                //Obtenemos el tiempo que hemos tardado en completar el nivel
                bestTime = PlayerPrefs.GetFloat(levelToLoad + "_time");
            }*/

            //Si el número de gemas recogidas es igual al número total de gemas del nivel
            /*if (gemCollected >= totalGems)
            {
                gemBadge.SetActive(true);
            }*/

            //Si el mejor tiempo es menor que el tiempo predefinido y a su vez no es 0
            /*if (bestTime <= targetTime && bestTime != 0)
            {
                timeBadge.SetActive(true);
            }*/

            //Por defecto todos los que sean niveles estarán bloqueados
            isLocked = true;

            //El nivel que hay que chequear no está vacío
            if (levelToCheck != null)
            {
                //Si existe en el archivo de guardado una Key que sea el nombre del nivel actual con _unlocked
                if (PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    //El valor de esa key sea 1, para saber si ese nivel está desbloqueado
                    if (PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        //El nivel queda desbloqueado
                        isLocked = false;
                    }
                }
            }

            //Si el nivel que quiero cargar es el mismo que quiero chequear, cosa que solo pasará con el nivel 1
            if (levelToLoad == levelToCheck)
            {
                //El nivel estará desbloqueado
                isLocked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
