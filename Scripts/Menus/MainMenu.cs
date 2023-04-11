using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class MainMenu : MonoBehaviour
{
    // Inputs
    public TMP_InputField userClass;
    public TMP_InputField userRoleNumber;
    public TextMeshProUGUI textDisplay;

    public void Ingresar()
    {
        string c = userClass.text;
        string rn = userRoleNumber.text;

        // Pedimos datos hasta que el usuario los proporcione de forma correcta.
        if(ValidateUser(c, rn)){
            // Perpetuamos los datos de logs
            GameObject logObject = GameObject.Find("ContenedorScript");
            PlayerData playerData = logObject.GetComponent<PlayerData>();
            playerData.group = c;
            playerData.listNumber = int.Parse(rn);

            // Cambiamos de Escena.
            SceneManager.LoadScene("MenuDificultad");
        }else{
            // Mostramos mensaje de Error.
            textDisplay.color = new Color32(168, 0, 0, 255);
        }
    }

    // Validamos que los datos ingresados sean correctos.
    private bool ValidateUser(string userClass, string userRoleNumber)
    {
        return Regex.IsMatch(userRoleNumber, "^[0-9]+$") && Regex.IsMatch(userClass, "^[A-Z]$");
    }

    // Cerrar juego
    public void CloseGame(){
        Application.Quit();
    }

    void Update()
    {
        
    }
}