using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    public GameObject defeat;
    public TextMeshProUGUI defeatText;

    // Start is called before the first frame update
    void Start()
    {
        defeat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fence")
        {
            defeat.SetActive(true);

            if (Level3Vars.total < 7)
            {
                defeatText.text = "Oh no!\nvuelve a intentarlo!";
                defeatText.text += "\nContestaste " + Level3Vars.correctAnswered + " de " + Level3Vars.total;
            }
            else
            {
                defeatText.text = "Por poco! A la próxima lo conseguirás";
                defeatText.text += "\nContestaste " + Level3Vars.correctAnswered + " de " + Level3Vars.total;
            }

            EndLevel();
        }  
    }

    private void EndLevel()
    {
        Level3Vars.total = 0;
        Level3Vars.correctAnswered = 0;

        Time.timeScale = 0f;
    }
}
