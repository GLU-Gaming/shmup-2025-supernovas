using UnityEngine;


public class Menu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    void Start()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        //check if pause button (escape key) is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;   
        }
    }
    public void Continue()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
