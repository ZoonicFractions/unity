using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerControl : MonoBehaviour
{
    private CharacterController characterController;
    private float speed, yspeed;
    private const float X_SPEED = 3.5f;
    private Vector3 movement;

    private Animator animator;

    private float originalStepOffset;


    private float animationDuration = 3;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Level3Vars.total < 4)
            speed = 4;
        else if(Level3Vars.total >= 4 && Level3Vars.total < 7)
            speed = 6;
        else 
            speed = 8;


        if(Time.time < animationDuration)
        {
            characterController.Move(Vector3.forward * Time.deltaTime * speed);
            return;
        }


        
        // Reset movement vector
        movement = Vector3.zero;
        // x
        movement.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * X_SPEED;
        // y with calculated gravity
        yspeed = -0.01f;
        if (!characterController.isGrounded)
        {
            characterController.stepOffset = 0;
        }
        else
        {
            characterController.stepOffset = originalStepOffset;
            if (Input.GetKeyDown("space"))
            {
                if(animator != null)
                {
                    animator.SetTrigger("jump");
                }
                yspeed = 3;
            }
        }
        // z 
        movement.z = speed * Time.deltaTime;

        movement.y = yspeed;

        characterController.Move(movement);

        if(animator != null)
        {
            if(!OptionVars.correct && OptionVars.exitTrigger)
            {
                animator.SetTrigger("pain");
            }
        }
    }

}
