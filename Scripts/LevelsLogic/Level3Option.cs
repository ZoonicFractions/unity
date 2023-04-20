using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Level3Option : MonoBehaviour
{
    // Start is called before the first frame update
    public int fracID;
    public TextMeshProUGUI num, den;
    private Fraction f;
    private const int MAX_MULT = 10;
    void Start()
    {
        GenerateOptions();
    }

    private void GenerateOptions()
    {
        f = Level3Vars.fractions[fracID];
    }

    // Update is called once per frame
    void Update()
    {
        num.text = f.num.ToString();
        den.text = f.den.ToString();
        OptionVars.exitTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            Level3Vars.total++;
            if (fracID == Level3Vars.correctID)
            {
                OptionVars.correct = true;
                Level3Vars.correctAnswered++;
            }
            else OptionVars.correct = false;
            Debug.Log("total " + Level3Vars.total);
            Debug.Log("correctans " + Level3Vars.correctAnswered);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            OptionVars.exitTrigger = true;
        }
    }
}

public class OptionVars
{
    public static bool correct = false, exitTrigger = false;
}
