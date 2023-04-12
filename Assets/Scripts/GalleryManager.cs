using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GalleryManager : MonoBehaviour
{
    public Button[] pageButtons;
    public GameObject[] pages;

    private int maxUnlockedPage = 0;

    private void Start()
    {
        //Busca el n�mero de la p�gina m�xima desbloqueada
        if (PlayerPrefs.HasKey("MaxUnlockedPage"))
        {
            maxUnlockedPage = PlayerPrefs.GetInt("MaxUnlockedPage");
        }

        //Configura los botones de la galer�a
        for (int i = 0; i < pageButtons.Length; i++)
        {
            int pageIndex = i + 1;
            if (pageIndex > maxUnlockedPage)
            {
                pageButtons[i].interactable = false;
            }
            else
            {
                pageButtons[i].interactable = true;
                int indexToLoad = pageIndex - 1;
                pageButtons[i].onClick.AddListener(() => LoadPage(indexToLoad));
            }
        }
    }

    //Carga la p�gina correspondiente al bot�n pulsado
    private void LoadPage(int index)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == index);
        }
    }

    //Actualiza la p�gina m�xima desbloqueada si el jugador ha llegado a una puntuaci�n suficiente
    public void UpdateMaxUnlockedPage(int newMaxPage)
    {
        if (newMaxPage > maxUnlockedPage)
        {
            maxUnlockedPage = newMaxPage;
            PlayerPrefs.SetInt("MaxUnlockedPage", maxUnlockedPage);
        }
    }
}
