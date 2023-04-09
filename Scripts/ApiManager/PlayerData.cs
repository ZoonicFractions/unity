using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    // Logs Attributes.
    public string group;
    public int listNumber;
    public int difficulty;
    public int maxLevel;

    // Método que imprime los atributos de PlayerData en fromato JSON.
    public string ToString(){
        string txt = "{ ";
        txt += "\"group\": " + group + ", ";
        txt += "\"listNumber\": " + listNumber.ToString() + ", ";
        txt += "\"difficulty\": " + difficulty.ToString() + ", ";
        txt += "\"maxLevel\": " + maxLevel.ToString() + " }";

        return txt;
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