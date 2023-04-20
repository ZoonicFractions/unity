using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Level2_1Logic : MonoBehaviour
{
    public TextMeshProUGUI buttonLeft;
    public TextMeshProUGUI buttonMiddle;
    public TextMeshProUGUI buttonRight;

    public TextMeshProUGUI instructions;
    public TextMeshProUGUI timer;

    public Rigidbody bread;
    private Rigidbody breadClone;

    public float maxSpeed = 0.5f;

    private int selectOp;
    private string op;
    private int valueAns1;
    private int valueAns2;
    private int answer;
    private int pickResult;

    private float timerValue;

    public int range = 10;

    private bool clicked;
    private int score;

    private int round;

    private Vector3 pointLeft = new Vector3(-11.230999946594239f, 2.818000078201294f, -37.926998138427737f);
    private Vector3 pointMiddle = new Vector3(-12.876985549926758f, 3.677377700805664f, -36.97832489013672f);
    private Vector3 pointRight = new Vector3(-13.383000373840332f, 2.611999988555908f, -35.32400131225586f);

    
    


    // Start is called before the first frame update
    void Start()
    {
        Play();
        timerValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;

        if (round < 10)
        {
            timerValue += Time.deltaTime;
        }
    }

    void OnGUI()
    {
        string value = Math.Round(timerValue).ToString();
        timer.text = "Timer: " + value.Substring(0, value.Length) + " s.";
    }

    private void Play()
    {
        breadClone = Instantiate(bread);
        this.breadClone.transform.position = new Vector3(-11.31205940246582f, 2.3214001655578615f, -35.373130798339847f);
        

        round++;

        clicked = false;

        System.Random rand = new System.Random();
        selectOp = rand.Next(4)+1;
        valueAns1 = rand.Next(range) + 1;
        valueAns2 = rand.Next(range) + 1;

        if (selectOp == 1)
        {
            op = " + ";
            answer = valueAns1 + valueAns2;
        }
        else if (selectOp == 2)
        {
            op = " - ";
            if (valueAns1 >= valueAns2)
            {
                answer = valueAns1 - valueAns2;
            }
            else
            {
                answer = valueAns2 - valueAns1;
            }
            
        }
        else if(selectOp == 3)
        {
            op = " / ";
            if (valueAns1 >= valueAns2)
            {
                answer = valueAns1;
                valueAns1 = answer * valueAns2;
            }
            else
            {
                answer = valueAns2;
                valueAns2 = answer * valueAns1;
            }
        }
        else
        {
            op = " * ";
            answer = valueAns1 * valueAns2;
        }

        if (valueAns1 >= valueAns2)
        {
            instructions.text = "¿Qué pajaro tiene la respuesta correcta de la siguiente operación?\n" +
            valueAns1.ToString() + op + valueAns2.ToString();
        }
        else
        {
            instructions.text = "¿Qué pajaro tiene la respuesta correcta de la siguiente operación?\n" +
            valueAns2.ToString() + op + valueAns1.ToString();
        }
        generateOptions();
    }

    public void generateOptions()
    {
        System.Random rand = new System.Random();
        pickResult = rand.Next(3);
        int random1;
        int random2;
        
        if(selectOp == 1)
        {
            random1 = rand.Next(range + range + 1);
            random2 = rand.Next(range + range + 1);

            while(random1 == random2 || random1 == answer) { random1 = rand.Next(range + range + 1); }
            while (random2 == random1 || random2 == answer) { random2 = rand.Next(range + range + 1); }
        }
        else if(selectOp == 2)
        {
            random1 = rand.Next(range + 1);
            random2 = rand.Next(range + 1);

            while (random1 == random2 || random1 == answer) { random1 = rand.Next(range + 1); }
            while (random2 == random1 || random2 == answer) { random2 = rand.Next(range + 1); }
        }
        else if (selectOp == 3)
        {
            random1 = rand.Next(range + 1);
            random2 = rand.Next(range + 1);

            while (random1 == random2 || random1 == answer) { random1 = rand.Next(range + 1); }
            while (random2 == random1 || random2 == answer) { random2 = rand.Next(range + 1); }
        }
        else
        {
            random1 = rand.Next(range * range);
            random2 = rand.Next(range * range);

            while (random1 == random2 || random1 == answer) { random1 = rand.Next(range * range); }
            while (random2 == random1 || random2 == answer) { random2 = rand.Next(range * range); }
        }
        
        if(pickResult == 0)
        {
            buttonLeft.text = answer.ToString();
            buttonMiddle.text =  random1.ToString();
            buttonRight.text = random2.ToString();
        }
        else if(pickResult == 1)
        {
            buttonLeft.text = random1.ToString();
            buttonMiddle.text = answer.ToString();
            buttonRight.text = random2.ToString();
        }
        else
        {
            buttonLeft.text = random1.ToString();
            buttonMiddle.text = random2.ToString();
            buttonRight.text = answer.ToString();
        }
    }

    public void checkLeft()
    {     
        if (clicked == false)
        {
            StartCoroutine(MoveToTarget(breadClone,pointLeft));

            if (buttonLeft.text == answer.ToString())
            {
                score += 10; 
               
                instructions.text = "¡CORRECTO!";
                
            }
            else
            {
                instructions.text = "¡INCORRECTO!";
            }
            clicked = true;

            if (round == 10)
            {
                instructions.text += "\n¡Terminaste!\nTu puntaje es de " + score.ToString() + "/100";
            }

            if (round < 10)
            {
                Invoke("Play", 3.0f);
            }
            else
            {
                Invoke("finishLevel", 5.0f);
            }
        }
    }

    public void checkMiddle()
    {
        if (clicked == false)
        {
            StartCoroutine(MoveToTarget(breadClone, pointMiddle));

            if (buttonMiddle.text == answer.ToString())
            {
                score += 10;
               
                instructions.text = "¡CORRECTO!";
            }
            else
            {
                instructions.text = "¡INCORRECTO!";
            }
            clicked = true;

            if (round == 10)
            {
                instructions.text += "\n¡Terminaste!\nTu puntaje es de " + score.ToString() + "/100";
            }

            if (round < 10)
            {
                Invoke("Play", 3.0f);
            }
            else
            {
                Invoke("finishLevel", 5.0f);
            }
        }
    }

    public void checkRight()
    {
        if (clicked == false)
        {
            StartCoroutine(MoveToTarget(breadClone, pointRight));

            if (buttonRight.text == answer.ToString())
            {
                score += 10;
               
                instructions.text = "¡CORRECTO!";
            }
            else
            {
                instructions.text = "¡INCORRECTO!";
            }
            clicked = true;

            if (round == 10)
            {
                instructions.text += "\n¡Terminaste!\nTu puntaje es de " + score.ToString() + "/100";
            }

            if (round < 10)
            {
                Invoke("Play", 3.0f);
            }
            else
            {
                Invoke("finishLevel", 5.0f);
            }
        }
    }

    IEnumerator MoveToTarget(Rigidbody a,Vector3 target) {
    while (Vector3.Distance(a.transform.position, target) > 0.0001f) {
        a.transform.position = Vector3.MoveTowards(a.transform.position, target, maxSpeed * Time.deltaTime);
        yield return null;
    }
}

    private void finishLevel()
    {
        SceneManager.LoadScene("Scenes/Level2");
    }

}
