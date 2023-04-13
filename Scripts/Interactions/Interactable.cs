using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject interactMessageActive;
    public GameObject interactMessageUnactive;
    public int level;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject logObject = GameObject.Find("ContenedorScript");
            PlayerData playerData = logObject.GetComponent<PlayerData>();

            isInRange = level <= playerData.maxLevel + 1;
            interactMessageActive.SetActive(isInRange);
            interactMessageUnactive.SetActive(!isInRange);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            interactMessageActive.SetActive(isInRange);
            interactMessageUnactive.SetActive(isInRange);
        }
    }
}
