using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
 
    void Start()
    {
        
    }

    void Update()
    {
        
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
