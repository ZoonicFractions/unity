using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SelectLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Level1()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Scenes/Level2");
        Cursor.lockState = CursorLockMode.None;
    }

    public void Level3()
    {
        SceneManager.LoadScene("Scenes/Level3");
        Cursor.lockState = CursorLockMode.None;
    }

    public void Level11()
    {
        SceneManager.LoadScene("Scenes/Level1.1");
        Cursor.lockState = CursorLockMode.None;
    }

    public void Level21()
    {
        SceneManager.LoadScene("Scenes/Level2.1");
        Cursor.lockState = CursorLockMode.None;
    }

    public void Level31()
    {
        SceneManager.LoadScene("Scenes/Level3.1");
        Cursor.lockState = CursorLockMode.None;
    }

}
