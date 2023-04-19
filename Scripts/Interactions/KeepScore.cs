using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScore : MonoBehaviour
{

    public static int Score = 0;
    public static int vaca = 0;
    public static int cerdo = 0;
    public static int gallina = 0;
    public static int suma = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collider){
        Debug.Log(collider.gameObject.name);
        if(collider.gameObject.name == "Vaca"){
            vaca += 100;
        } else if(collider.gameObject.name == "Cerdo"){
            cerdo += 50;
        } else if(collider.gameObject.name == "Gallina") {
            gallina += 25;
        }

        suma = vaca + gallina + cerdo;
    }

    

    void OnGUI(){
        GUI.Box(new Rect(100,100,200,100), "Vacas (valor =100): " + vaca.ToString() + "\n Cerdos (Valor = 50): " + cerdo.ToString() + "\nGallinas (Valor = 25): " + gallina.ToString() + "\ntotal: " + suma);
    }
}
