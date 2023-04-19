using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Level3Logic : MonoBehaviour
{
    private Fraction f1, f2;
    public TextMeshProUGUI num1, num2, den1, den2, score;
    private const int MAX_MULT = 10;
    public List<Texture> imgs;
    private RawImage img;
    private int imageType = 0;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "100";
        img = GetComponentInChildren<RawImage>();
        GenerateImgType();
        GenerateFractions();
        GenerateCorrectID();
    }

    private void GenerateCorrectID()
    {
        Level3Vars.correctID = Random.Range(0, 3);
    }

    private void GenerateImgType()
    {
        imageType = Random.Range(0,2);
    }

    private void GenerateFractions()
    {
        f1 = Fraction.GenerateRandomFraction();
        f2 = Fraction.GenerateRandomFraction();
        if (imageType == 0)
        {
            Level3Vars.res = f1 * f2;
        }
        else
        {
            try
            {
                Level3Vars.res = f1 / f2;
            } catch(ArgumentException e)
            {
                Debug.Log(e.Message);
                GenerateFractions();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        img.texture = imgs[imageType];
        num1.text = f1.num.ToString();
        num2.text = f2.num.ToString();
        den1.text = f1.den.ToString();
        den2.text = f2.den.ToString();
        if(OptionVars.exitTrigger)
        {
            GenerateImgType();
            SetScore();
            GenerateFractions();
            GenerateCorrectID();
            score.text = Level3Vars.score.ToString();
        }
    }

    private void SetScore()
    {
        Level3Vars.score = Mathf.RoundToInt(((float)Level3Vars.correctAnswered / Level3Vars.total * 100f));
    }

}

public class Level3Vars
{
    public static Fraction res;
    public static int correctID, total = 0, correctAnswered = 0;
    public static float score;
}