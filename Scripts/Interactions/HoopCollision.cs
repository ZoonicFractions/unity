using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopCollision : MonoBehaviour
{
    public bool triggered = false;
    public string side;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "LeftHoop" && triggered == false)
        {
            Debug.Log("Left");
            side = "left";
            triggered = true;
        }
        else if (other.name == "MiddleHoop" && triggered == false)
        {
            Debug.Log("Middle");
            side = "middle";
            triggered = true;
        }
        else if (other.name == "RightHoop" && triggered == false)
        {
            Debug.Log("Right");
            side = "right";
            triggered = true;
        }
    }
}
