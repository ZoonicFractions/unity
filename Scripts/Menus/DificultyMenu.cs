using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;

public class DificultyMenu : MonoBehaviour
{
    public void SelectEasy(){
        GameObject logObject = GameObject.Find("ContenedorScript");
        PlayerData playerData = logObject.GetComponent<PlayerData>();
        playerData.difficulty = 1;

        // Checamos el maxLevel y cambiamos de escena.
        StartCoroutine(playerData.GetLogs());
        GoToZoo();
    }

    public void SelectDifficult(){
        GameObject logObject = GameObject.Find("ContenedorScript");
        PlayerData playerData = logObject.GetComponent<PlayerData>();
        playerData.difficulty = 2;

        // Checamos el maxLevel y cambiamos de escena.
        StartCoroutine(playerData.GetLogs());
        GoToZoo();
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Scenes/MenuPrincipal");
    }

    public void GoToZoo()
    {
        SceneManager.LoadScene("Scenes/Zoo");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}