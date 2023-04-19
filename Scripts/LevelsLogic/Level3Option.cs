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
        if (fracID == Level3Vars.correctID)
        {
            f = Level3Vars.res;
        }
        else f = Fraction.GenerateRandomFraction();
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
        Level3Vars.total++;
        if (fracID == Level3Vars.correctID)
        {
            OptionVars.correct = true;
            Level3Vars.correctAnswered++;
        }
        Debug.Log("total " + Level3Vars.total);
        Debug.Log("correctans " + Level3Vars.correctAnswered);
    }

    private void OnTriggerExit(Collider other)
    {
        OptionVars.exitTrigger = true;
    }
}

public class OptionVars
{
    public static bool correct = false, exitTrigger = false;
}
