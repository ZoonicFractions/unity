using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelNandoLogic : MonoBehaviour
{
    public static LevelNandoLogic Instance;

    public TextMeshProUGUI instrucciones;
    public TextMeshProUGUI animales;
    public TextMeshProUGUI finish;


    private int cows;
    private int pigs;
    private int ducks;
    private int total;
    private int repetitions;
    private int puntaje;
    private List<int> reps = new();
    private int score;

    int[] puntajes =new int[] {375,250,125,50,400,325};

    private void Awake(){
        Instance = this;
    }


    // Start is called before the first frame update
    void Start(){
        newRound();
    }


    private void newRound(){
        System.Random rand = new System.Random();


        
        for(puntaje=0; puntaje <= puntajes.Length; puntaje++){
            instrucciones.text = "DIA " + (repetitions + 1) + " DE 5,\n Segun el puntaje de los animales, tienes que hacer el valor " + puntajes[puntaje].ToString() +  " para completar el minijuego";
            score = puntajes[puntaje];
        }

        total = KeepScore.suma - score;

    }


     public void ScoreUpdate(){

        if(total > 1)
        {
            total -= 1;
            animales.text = "Te faltan " + (KeepScore.suma - score) + " puntos";
        }
        else if (total == 1)
        {
            total -= 1;
            animales.text = "�Ya comieron Suficiente!";

            if (score == 0)
            {
                reps.Add(1);
                animales.text = animales.text + "\n�BIEN HECHO!";
                repetitions += 1;
            }
            else
            {
                reps.Add(0);
                animales.text = animales.text + "\n�No repartiste la comida correctamente!";
                repetitions += 1;
            }
        }
        else if (total <=0)
        {
            animales.text = "�Repartiste demasiada comida!";
        }

        if(total == 0){

            if (repetitions < 5){
                Invoke("newRound", 5.0f);
            }
            else if (repetitions == 5){
                int correct = 0;

                for(int i = 0; i < 5; i++){
                    if (reps[i] == 1)
                    {
                        correct += 1;
                    }
                    Debug.Log("Ronda " + (i+1) + ": " + reps[i]);
                }

                finish.text = "�Nivel Completado!\n acertaste " + correct + " de 5 preguntas";

                Invoke("finishLevel", 7.0f);
            }
        }

    }


    private void finishLevel()
    {
        SceneManager.LoadScene("Scenes/Zoo");
    }
}
