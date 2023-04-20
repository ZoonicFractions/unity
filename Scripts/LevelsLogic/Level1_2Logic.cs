using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;


public class Level1_2Logic : MonoBehaviour
{
    public static Level1_2Logic Instance;

    public TextMeshProUGUI instrucciones;
    public TextMeshProUGUI Animales;
    public TextMeshProUGUI timer;

    private GameObject vacaClone1;
    private GameObject cerdoClone1;
    private GameObject gallinaClone1;

    private GameObject vacaClone2;
    private GameObject cerdoClone2;
    private GameObject gallinaClone2;

    private GameObject vacaClone3;
    private GameObject cerdoClone3;
    private GameObject gallinaClone3;

    public GameObject vaca;
    public GameObject cerdo;
    public GameObject gallina;

    private int randomNumber;
    private int actual;
    private int repetitions;
    private List<int> reps = new();
    private int score;

    private int correctAns;
    private int scoreCheck;

    private float timerValue;

    public KeepScore script2;


    private void Awake(){
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        newRound();
        timerValue = 0;
    }

    void Update()
    {
        if (repetitions < 5)
        {
            timerValue += Time.deltaTime;
        }
    }

    void OnGUI()
    {
        string value = Math.Round(timerValue).ToString();
        timer.text = "Timer: " + value.Substring(0, value.Length) + " s.";
    }


    private void newRound()
    {
        script2.ResetScore();
        NewAnimals();
        

        scoreCheck = 0;

        System.Random rand = new System.Random();
        randomNumber = rand.Next(1, 21) * 25;

        instrucciones.text = "DIA " + (repetitions + 1) + " DE 5,\n Según el puntaje de los animales, tienes que conseguir el valor " + randomNumber +  " para completar el minijuego";
        score = randomNumber;
        ScoreUpdate();
    }

    public void ScoreUpdate()
    {
        actual = score - KeepScore.total;

        if (KeepScore.total < score && scoreCheck == 0){
            Animales.text = "Te siguen haciendo falta " + (score - KeepScore.total) + " puntos, continua!!";

        } else if (KeepScore.total > score && scoreCheck == 0) {
            reps.Add(0);
            Animales.text = "Te pasaste de los puntos requeridos";
            repetitions += 1;
            scoreCheck += 1;

        } else if (KeepScore.total == score && scoreCheck == 0){
            reps.Add(1);
            Animales.text = "Perfecto!! Avanzaste a la siguiente ronda";
            repetitions += 1;
            scoreCheck = +1; 

        }

        if(actual <= 0){

            if (repetitions < 5){
                Invoke("newRound", 5.0f);
                
            }
            else if (repetitions == 5){

                for(int i = 0; i < 5; i++){
                    if (reps[i] == 1)
                    {
                        correctAns += 1;
                    }
                    Debug.Log("Ronda " + (i+1) + ": " + reps[i]);
                }

                Animales.text = "�Nivel Completado!\n acertaste " + correctAns + " de 5 preguntas"; 

                Invoke("finishLevel", 7.0f);
            }
        }
    }
    private void finishLevel()
    {
        SceneManager.LoadScene("Scenes/Zoo");
    }

    private void NewAnimals() 
    {
        if(repetitions > 0)
        {
            DestroyAnimals();
        }

        vacaClone1 = Instantiate(vaca);
        vacaClone1.transform.position = SpawnCoordinates();
        vacaClone2 = Instantiate(vaca);
        vacaClone2.transform.position = SpawnCoordinates();
        vacaClone3 = Instantiate(vaca);
        vacaClone3.transform.position = SpawnCoordinates();

        cerdoClone1 = Instantiate(cerdo);
        cerdoClone1.transform.position = SpawnCoordinates();
        cerdoClone2 = Instantiate(cerdo);
        cerdoClone2.transform.position = SpawnCoordinates();
        cerdoClone3 = Instantiate(cerdo);
        cerdoClone3.transform.position = SpawnCoordinates();

        gallinaClone1 = Instantiate(gallina);
        gallinaClone1.transform.position = SpawnCoordinates();
        gallinaClone2 = Instantiate(gallina);
        gallinaClone2.transform.position = SpawnCoordinates();
        gallinaClone3 = Instantiate(gallina);
        gallinaClone3.transform.position = SpawnCoordinates();
    }

    private void DestroyAnimals()
    {
        Destroy(vacaClone1);
        Destroy(vacaClone2);
        Destroy(vacaClone3);

        Destroy(cerdoClone1);
        Destroy(cerdoClone2);
        Destroy(cerdoClone3);

        Destroy(gallinaClone1);
        Destroy(gallinaClone2);
        Destroy(gallinaClone3);
    }

    private Vector3 SpawnCoordinates()
    {
        System.Random rand = new System.Random();
        float x = rand.Next(-15, 85) / 10;
        float y = 3;
        float z = rand.Next(-155, -95) / 10;

        Vector3 coordinates = new(x, y, z);
        return coordinates;
    }

}
