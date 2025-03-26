using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        //check if pause button (escape key) is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeInHierarchy)
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
            }
            else 
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    public void Continue()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    //Go To Menu
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    //Load The Game
    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
    }
}
