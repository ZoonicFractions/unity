using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    Vector3 originalPos;
    public GameObject crow;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(0,20,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (crow.tag == "Player")
        {
            crow.transform.position = originalPos;
            crow.transform.rotation = new Quaternion(0f,-1f, 0f, 0f);
        }
    }
}
