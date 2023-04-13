using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    // Logs Attributes.
    public string group;
    public int listNumber;
    public int difficulty;
    public int maxLevel;

    // Game Attributes.
    public float gameTime;
    public float gameGrade;

    // Método que imprime los atributos de PlayerData en fromato JSON.
    public string ToString(){
        string txt = "{ ";
        txt += "\"group\": " + group + ", ";
        txt += "\"listNumber\": " + listNumber.ToString() + ", ";
        txt += "\"difficulty\": " + difficulty.ToString() + ", ";
        txt += "\"maxLevel\": " + maxLevel.ToString() + " }";

        return txt;
    }

    // Con el api checamos cual es el nivel más alto de un juagador.
    public IEnumerator GetLogs(){
        // Api Url
        string url = "http://127.0.0.1:8000/api/view-logs-student/";

        // Alteramos el url segun los datos del jugador.
        url += difficulty + "/" + group + "/" + listNumber.ToString() + "/";

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
                    int max = 0;
                    foreach(LogReceive log in response.logs){
                        if(log.difficulty == difficulty && log.level > maxLevel){
                            if(difficulty == 1 && log.grade >= 80.0f){
                                max = log.level;
                            }else if(difficulty == 2 && log.grade == 100.0f){
                                max = log.level;
                            }
                        }
                    }
                    maxLevel = max;
                }else{
                    maxLevel = 0;
                }
            }
        }
    }

    // Mandamos datos de juego a la DB.
    public IEnumerator SendLog(int level, float grade, float time){
        // Api Url
        string url = "http://127.0.0.1:8000/api/create-log";

        // Creamos el LogSend.
        LogSend sendLog = new LogSend();
        sendLog.classroom = group;
        sendLog.role_number = listNumber;
        sendLog.difficulty = difficulty;
        sendLog.level = level;
        sendLog.grade = grade;
        sendLog.time = time;

        // Lo convertimos a json.
        string json = JsonUtility.ToJson(sendLog);

        // Hacemos la Web Request
        using (UnityWebRequest www = UnityWebRequest.Put(url, json))
        {
            yield return www.SendWebRequest();
 
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Log sent successfully");
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

    // En la timeline va antes que Start
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}