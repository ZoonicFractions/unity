using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegation : MonoBehaviour
{
    public void ReturnToZoo()
    {
        SceneManager.LoadScene("Scenes/Zoo");
    }
}
