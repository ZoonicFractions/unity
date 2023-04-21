using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                defeatText.text = "Por poco! A la pr�xima lo conseguir�s";
                defeatText.text += "\nContestaste " + Level3Vars.correctAnswered + " de " + Level3Vars.total;
            }

            Invoke("EndLevel", 3f);
        }  
    }

    private void EndLevel()
    {
        // Resetting level
        Level3Vars.total = 0;
        Level3Vars.correctAnswered = 0;
        
        // Changing Scene
        SceneManager.LoadScene("Scenes/Level3");
    }
}
