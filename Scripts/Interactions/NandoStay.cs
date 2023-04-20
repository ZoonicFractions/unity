using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NandoStay : MonoBehaviour{

    void OnCollisionEnter(Collision collider){
        Debug.Log(collider.gameObject.name);
        if(collider.gameObject.name == "Vaca"){
            KeepScore.vaca += 100;
        } else if(collider.gameObject.name == "Cerdo"){
            KeepScore.cerdo += 100;
        } else if(collider.gameObject.name == "Gallina") {
            KeepScore.gallina +=100;
        }
    }

}
