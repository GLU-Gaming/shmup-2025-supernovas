using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject victoryUI;
    public GameObject player;

    void Awake()
    {
        pauseMenuUI.SetActive(false);

        player = FindAnyObjectByType<Player>().gameObject;
        Health playerHealth = player.GetComponent<Health>();
        playerHealth.EntityDied += GameOver;
    }


    void GameOver()
    {
        player.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
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
        Time.timeScale = 1f;
    }
    //Load The Game
    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}
