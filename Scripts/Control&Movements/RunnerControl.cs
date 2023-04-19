using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerControl : MonoBehaviour
{
    private CharacterController characterController;
    private float speed, yspeed;
    private Vector3 movement;
    private double timeRate = 0.2f;
    private double nextUpdate = 0;

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

        yspeed = Physics.gravity.y * Time.deltaTime;

        
        // Reset movement vector
        movement = Vector3.zero;
        // x
        if(Input.GetAxisRaw("Horizontal") != 0 && Time.time > nextUpdate) 
        {
            if (Input.GetAxisRaw("Horizontal") > 0 && transform.position.x < 2)
            {
                movement.x = 3;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0 && transform.position.x > -2)
            {
                movement.x = -3;
            }
            nextUpdate = Time.time + timeRate;
        }
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
