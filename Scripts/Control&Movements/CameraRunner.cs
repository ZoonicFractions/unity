using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunner : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 positions;
    private Vector3 moveCamera;

    private float animationDuration = 3, transition = 0;
    private Vector3 animationOffset = new Vector3(0, 5, 5);
    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        // Working with an offset
        positions = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveCamera = positions + lookAt.position;
        moveCamera.x = 0 ;
        moveCamera.y = 3 ;

        if(transition > 1)
        {
            // Normal flow
            transform.position = moveCamera;
        }
        else
        {
            // Start animation
            transform.position = Vector3.Lerp(moveCamera + animationOffset, moveCamera, transition);
            transition += Time.deltaTime / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }

    }
}
