using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1; 
    }

    void Update()
    {
        
    }
    //Go To Menu
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    //Load The Game
    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }
    // Quit Game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
