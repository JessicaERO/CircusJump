using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GalleryManager : MonoBehaviour
{
    public GameObject gameManager;
    public Button[] pageButtons;
    public GameObject[] pages;

    private int maxUnlockedPage = 0;

    private void Start()
    {
        //Busca el número de la página máxima desbloqueada
        //if (PlayerPrefs.HasKey("MaxUnlockedPage"))
        //{
        //    maxUnlockedPage = PlayerPrefs.GetInt("MaxUnlockedPage");
        //}

        UpdateGalleryButtons();
    }

    public void UpdateGalleryButtons()
    {
        if (gameManager.GetComponent<GameManager>().PassedLevel_1 == 1) //si nos hemos pasado el primer nivel
        {
            pageButtons[0].interactable = true; //activamos el boton para poder usarlo
        }
        if (gameManager.GetComponent<GameManager>().PassedLevel_2 == 1) //si nos hemos pasado el primer nivel
        {
            pageButtons[1].interactable = true; //activamos el boton para poder usarlo
        }
        if (gameManager.GetComponent<GameManager>().PassedLevel_3 == 1) //si nos hemos pasado el primer nivel
        {
            pageButtons[2].interactable = true; //activamos el boton para poder usarlo
        }
        if (gameManager.GetComponent<GameManager>().PassedLevel_4 == 1) //si nos hemos pasado el primer nivel
        {
            pageButtons[3].interactable = true; //activamos el boton para poder usarlo
        }
        if (gameManager.GetComponent<GameManager>().PassedLevel_5 == 1) //si nos hemos pasado el primer nivel
        {
            pageButtons[4].interactable = true; //activamos el boton para poder usarlo
        }
        if (gameManager.GetComponent<GameManager>().PassedLevel_6 == 1) //si nos hemos pasado el primer nivel
        {
            pageButtons[5].interactable = true; //activamos el boton para poder usarlo
        }
        if (gameManager.GetComponent<GameManager>().PassedLevel_7 == 1) //si nos hemos pasado el primer nivel
        {
            pageButtons[6].interactable = true; //activamos el boton para poder usarlo
        }
        if (gameManager.GetComponent<GameManager>().PassedLevel_8 == 1) //si nos hemos pasado el primer nivel
        {
            pageButtons[7].interactable = true; //activamos el boton para poder usarlo
        }
        if (gameManager.GetComponent<GameManager>().PassedLevel_9 == 1) //si nos hemos pasado el primer nivel
        {
            pageButtons[8].interactable = true; //activamos el boton para poder usarlo
        }
        if (gameManager.GetComponent<GameManager>().PassedLevel_10 == 1) //si nos hemos pasado el primer nivel
        {
            pageButtons[9].interactable = true; //activamos el boton para poder usarlo
        }

    }
    //Carga la página correspondiente al botón pulsado
    public void LoadPage(int index)
    {
        pages[index].SetActive(true);
        //set active el boton de back para volver a quitar la pagina
        //sonido...
    }

    //Actualiza la página máxima desbloqueada si el jugador ha llegado a una puntuación suficiente
    public void UpdateMaxUnlockedPage(int newMaxPage)
    {
        if (newMaxPage > maxUnlockedPage)
        {
            maxUnlockedPage = newMaxPage;
            PlayerPrefs.SetInt("MaxUnlockedPage", maxUnlockedPage);
        }
    }
}
