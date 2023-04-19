using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Logic : MonoBehaviour
{
    public HoopCollision script;

    public GameObject crow;

    public TextMeshProUGUI LeftText;
    public TextMeshProUGUI MiddleText;
    public TextMeshProUGUI RightText;

    public TextMeshProUGUI instructions;

    private int selectOp;
    private string op;
    public int valueAns1;
    public int valueAns2;
    private int answer;
    private int pickResult;

    public int range = 10;

    private int score;

    private int round;
    public string side;

    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        side = script.side;
        triggered = script.triggered;

        if(triggered == true)
        {
            if(side == "left")
            {

                CheckLeft();
            }else if(side == "right")
            {
                CheckRight();
            }
            else if(side == "middle")
            {
                CheckMiddle();
            }
            script.triggered = false;
        }
    }

    private void Play()
    {

        // Starting Position
        crow.transform.position = new Vector3(0,20,0);
        crow.transform.rotation = new Quaternion(0f, -1f, 0f, 0f);

        // Access to public variable
        script.side = " ";
        side = " ";
        round++;

        // Random Values generation
        System.Random rand = new System.Random();
        selectOp = rand.Next(4) + 1;
        valueAns1 = (rand.Next(range) + 1) * (Random.Range(0, 2) * 2 - 1);
        valueAns2 = (rand.Next(range) + 1) * (Random.Range(0,2) * 2 - 1);

        while (selectOp == 3 && (valueAns1 == 0 || valueAns2 == 0))
        {
            valueAns1 = (rand.Next(range) + 1) * (Random.Range(0, 2) * 2 - 1);
            valueAns2 = (rand.Next(range) + 1) * (Random.Range(0, 2) * 2 - 1);
        }

        if (selectOp == 1)
        {
            op = " + ";
            answer = valueAns1 + valueAns2;
        }
        else if (selectOp == 2)
        {
            op = " - ";
            answer = valueAns1 - valueAns2;
        }
        else if (selectOp == 3)
        {
            op = " / ";

            if (valueAns1 < 0 && valueAns2 < 0)
            {
                if (valueAns1 >= valueAns2)
                {
                    answer = valueAns2;
                    valueAns2 = answer * valueAns1;

                    instructions.text = "¿Qué aro tiene la respuesta correcta de la siguiente operación?\n" +
            valueAns2.ToString() + op + valueAns1.ToString();
                }
                else if (valueAns2 >= valueAns1)
                {
                    answer = valueAns1;
                    valueAns1 = answer * valueAns2;

                    instructions.text = "¿Qué aro tiene la respuesta correcta de la siguiente operación?\n" +
        valueAns1.ToString() + op + valueAns2.ToString();
                }
            }
            else if (valueAns1 >= valueAns2)
            {
                answer = valueAns1;
                valueAns1 = answer * valueAns2;

                instructions.text = "¿Qué aro tiene la respuesta correcta de la siguiente operación?\n" +
        valueAns1.ToString() + op + valueAns2.ToString();
            }
            else if (valueAns2 >= valueAns1)
            {
                answer = valueAns2;
                valueAns2 = answer * valueAns1;

                instructions.text = "¿Qué aro tiene la respuesta correcta de la siguiente operación?\n" +
            valueAns2.ToString() + op + valueAns1.ToString();
            }
        }
        else
        {
            op = " * ";
            answer = valueAns1 * valueAns2;
        }

        if(selectOp != 3)
        {
            instructions.text = "¿Qué aro tiene la respuesta correcta de la siguiente operación?\n" +
        valueAns1.ToString() + op + valueAns2.ToString();
        }
        

        GenerateOptions();
    }

    public void GenerateOptions()
    {
        System.Random rand = new System.Random();
        pickResult = rand.Next(3);
        int random1;
        int random2;

        if (selectOp == 1)
        {
            random1 = rand.Next(range + range + 1) * (Random.Range(0, 2) * 2 - 1);
            random2 = rand.Next(range + range + 1) * (Random.Range(0, 2) * 2 - 1);

            while (random1 == random2||random1 == answer) { random1 = rand.Next(range + range + 1); }
            while (random2 == answer) { random2 = rand.Next(range + range + 1); }
        }
        else if (selectOp == 2)
        {
            random1 = rand.Next(range + 1);
            random2 = rand.Next(range + 1);

            while (random1 == random2 || random1 == answer) { random1 = rand.Next(range + 1); }
            while (random2 == answer) { random2 = rand.Next(range + 1); }
        }
        else if (selectOp == 3)
        {
            random1 = rand.Next(range + 1);
            random2 = rand.Next(range + 1);

            while (random1 == random2 || random1 == answer) { random1 = rand.Next(range + 1); }
            while (random2 == answer) { random2 = rand.Next(range + 1); }
        }
        else
        {
            random1 = rand.Next(range * range);
            random2 = rand.Next(range * range);

            while (random1 == random2 || random1 == answer) { random1 = rand.Next(range * range); }
            while (random2 == answer) { random2 = rand.Next(range * range); }
        }

        if (pickResult == 0)
        {
            LeftText.text = answer.ToString();
            MiddleText.text = random1.ToString();
            RightText.text = random2.ToString();
        }
        else if (pickResult == 1)
        {
            LeftText.text = random1.ToString();
            MiddleText.text = answer.ToString();
            RightText.text = random2.ToString();
        }
        else
        {
            LeftText.text = random1.ToString();
            MiddleText.text = random2.ToString();
            RightText.text = answer.ToString();
        }
    }

    public void CheckLeft()
    {
        if (triggered == true && side == "left")
        {
            

            if (LeftText.text == answer.ToString())
            {
                score += 10;

                instructions.text = "¡CORRECTO!";

            }
            else
            {
                Debug.Log(answer.ToString());
                Debug.Log(LeftText.text);
                instructions.text = "¡INCORRECTO!";
            }


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
                Invoke("NextLevel", 5.0f);
            }
        }
    }

    public void CheckMiddle()
    {
        if (triggered == true && side == "middle")
        {


            if (MiddleText.text == answer.ToString())
            {
                score += 10;

                instructions.text = "¡CORRECTO!";

            }
            else
            {
                Debug.Log(answer.ToString());
                Debug.Log(MiddleText.text);
                instructions.text = "¡INCORRECTO!";
            }


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
                Invoke("NextLevel", 5.0f);
            }
        }
    }

    public void CheckRight()
    {
        if (triggered == true && side == "right")
        {
            if (RightText.text == answer.ToString())
            {
                score += 10;

                instructions.text = "¡CORRECTO!";
            }
            else
            {
                Debug.Log(answer.ToString());
                Debug.Log(RightText.text);
                instructions.text = "¡INCORRECTO!";
            }

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
                Invoke("NextLevel", 5.0f);
            }
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene("Level2.1");
    }

}
