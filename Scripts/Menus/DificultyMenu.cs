using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;

public class DificultyMenu : MonoBehaviour
{
    // Api Url
    private string url = "http://127.0.0.1:8000/api/view-logs-student/";

    public void SelectEasy(){
        GameObject logObject = GameObject.Find("ContenedorScript");
        PlayerData playerData = logObject.GetComponent<PlayerData>();
        playerData.difficulty = 1;

        // Checamos el maxLevel y cambiamos de escena.
        StartCoroutine(GetPlayerLogs(playerData));
        GoToZoo();
    }

    public void SelectDifficult(){
        GameObject logObject = GameObject.Find("ContenedorScript");
        PlayerData playerData = logObject.GetComponent<PlayerData>();
        playerData.difficulty = 2;

        // Checamos el maxLevel y cambiamos de escena.
        StartCoroutine(GetPlayerLogs(playerData));
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

    IEnumerator GetPlayerLogs(PlayerData playerData){
        // Alteramos el url segun los datos del jugador.
        url += playerData.group + "/" + playerData.listNumber.ToString() + "/";
        // Hacemos la Web Request
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
 
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {   // Handling Web Request
                string txt = www.downloadHandler.text;

                // Definimos nuestro JSON.
                Response response = JsonUtility.FromJson<Response>(txt);

                // Parseamos los logs y buscamos nivel más alto
                if(response.status == "success"){
                    int maxLevel = 0;
                    foreach(Log log in response.logs){
                        if(log.difficulty == playerData.difficulty && log.level > maxLevel){
                            maxLevel = log.level;
                        }
                    }
                    playerData.maxLevel = maxLevel;
                }else{
                    playerData.maxLevel = 0;
                }

                // Imprimiendo nivel actual.
                Debug.Log(playerData.ToString());
            }
        }
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
