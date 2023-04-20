using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScore : MonoBehaviour
{

    public static int vaca = 0;
    public static int cerdo = 0;
    public static int gallina = 0;
    public static int total = 0;

    public Level1_2Logic script;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Vaca"){
            vaca += 100;
            total += 100;
            script.ScoreUpdate();
        } else if(collider.gameObject.tag == "Cerdo"){
            cerdo += 50;
            total += 50;
            script.ScoreUpdate();
        } else if(collider.gameObject.tag == "Gallina") {
            gallina += 25;
            total += 25;
            script.ScoreUpdate();
        }

    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Vaca")
        {
            vaca -= 100;
            total -= 100;
            script.ScoreUpdate();
        }
        else if (collider.gameObject.tag == "Cerdo")
        {
            cerdo -= 50;
            total -= 50;
            script.ScoreUpdate();
        }
        else if (collider.gameObject.tag == "Gallina")
        {
            gallina -= 25;
            total -= 25;
            script.ScoreUpdate();
        }
    }



    public void OnGUI(){
        GUI.Box(new Rect(100,100,200,100), "Vacas (valor =100): " + vaca.ToString() + "\n Cerdos (Valor = 50): " + cerdo.ToString() + "\nGallinas (Valor = 25): " + gallina.ToString() + "\ntotal: " + total);
    }

    public void ResetScore()
    {
        total = 0;
        vaca = 0;
        cerdo = 0;
        gallina = 0;
    }
}
