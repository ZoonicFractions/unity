using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Level3Logic : MonoBehaviour
{
    private Fraction f1, f2;

    public TextMeshProUGUI num1, num2, den1, den2, score, timer, victoryText;

    public GameObject victoryObject;
    public GameObject gameBoard;

    private const int MAX_MULT = 10;
    public List<Texture> imgs;
    private RawImage img;
    private int imageType = 0;

    private float timerValue;

    private void Awake()
    {
        gameBoard.SetActive(true);
        victoryObject.SetActive(false);
        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        score.text = "100";
        img = GetComponentInChildren<RawImage>();
        GenerateImgType();
        GenerateFractions();
        GenerateCorrectID();
        GenerateOptions();
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

    private void EndLevel()
    {
        // Obtaining DontDestroy Object
        GameObject logObject = GameObject.Find("ContenedorScript");
        PlayerData playerData = logObject.GetComponent<PlayerData>();

        // Storing player data
        playerData.gameTime = timerValue;
        playerData.gameGrade = Level3Vars.score;

        // Sending data to server
        StartCoroutine(playerData.SendLog(3));

        // Resetting player for next game.
        playerData.Reset();

        // Resetting level
        Level3Vars.total = 0;
        Level3Vars.correctAnswered = 0;

        // Changing Scene
        SceneManager.LoadScene("Scenes/Zoo");
    }

    private void GenerateOptions()
    {
        for(int i = 0, j = 0; i < 3; i++)
        {
            if (i == Level3Vars.correctID)
                Level3Vars.fractions[i] = Level3Vars.res;
            else Level3Vars.fractions[i] = Fraction.GenerateRandomFraction();

            if(i > 0)
            {
                while(Level3Vars.fractions[i] == Level3Vars.fractions[j])
                {
                    Level3Vars.fractions[i] = Fraction.GenerateRandomFraction();
                }
                j++;
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
            GenerateOptions();
            score.text = Level3Vars.score.ToString();
        }

        if (Level3Vars.total < 10)
        {
            timerValue += Time.deltaTime;
        }
        else if (Level3Vars.total == 10)
        {
            victoryObject.SetActive(true);
            victoryText.text += "\nAcertaste " + Level3Vars.correctAnswered + " de " + Level3Vars.total;
            victoryText.text += "\nTu puntje es: " + Level3Vars.score;
            gameBoard.SetActive(true);

            Invoke("EndLevel", 2f);
            Level3Vars.total += 1;
        }
    }

    void OnGUI()
    {
        string value = Math.Round(timerValue).ToString();
        timer.text = "Timer: " + value.Substring(0, value.Length) + " s.";
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
    public static Fraction[] fractions = new Fraction[3];
}