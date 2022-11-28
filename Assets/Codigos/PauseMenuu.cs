using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject instrucciones;
    // Update is called once per frame
  

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        instrucciones.SetActive(true);
        GameIsPaused = false;
    }

   public void Pause()
    {
        PauseMenuUI.SetActive(true);
        instrucciones.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
