using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void Start() 
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void PlayGame() 
    {
        Debug.Log("check");
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
