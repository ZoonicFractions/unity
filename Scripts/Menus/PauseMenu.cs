using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject normalUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        normalUI.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        normalUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void ReturnMenu()
    {
        // Obtaining DontDestroy Object
        GameObject logObject = GameObject.Find("ContenedorScript");
        PlayerData playerData = logObject.GetComponent<PlayerData>();

        // Reseting player data
        playerData.Reset();

        // Change scene
        SceneManager.LoadScene("Scenes/MenuPrincipal");
        gameIsPaused = false;
        Resume();
        Cursor.lockState = CursorLockMode.None;
    }

    public void SelectDificulty()
    {
        // Obtaining DontDestroy Object
        GameObject logObject = GameObject.Find("ContenedorScript");
        PlayerData playerData = logObject.GetComponent<PlayerData>();

        // Reseting player data
        playerData.Reset();

        // Change scene
        SceneManager.LoadScene("Scenes/MenuDificultad");
        gameIsPaused = false;
        Resume();
        Cursor.lockState = CursorLockMode.None;
    }

    public void ReturnZoo()
    {
        // Obtaining DontDestroy Object
        GameObject logObject = GameObject.Find("ContenedorScript");
        PlayerData playerData = logObject.GetComponent<PlayerData>();

        // Reseting player data
        playerData.Reset();

        // Change scene
        SceneManager.LoadScene("Scenes/Zoo");
        gameIsPaused = false;
        Resume();
    }
}
