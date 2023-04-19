using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearControl : MonoBehaviour
{
    Transform playerTransform;
    private Animator animator;
    private float offset = 3;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = playerTransform.position;
        if (animator != null)
        {
            if (transform.position.z != playerPosition.z)
            {
                animator.SetTrigger("Run Forward");
            }
            if(Input.GetKey("space"))
            {
                animator.SetTrigger("Jump");
            }
            if (!OptionVars.correct && OptionVars.exitTrigger) 
            {
                animator.SetTrigger("Attack1");
            }
        }
        if(Level3Vars.total < 10)
        {
            transform.position = new Vector3(playerPosition.x, playerPosition.y, Mathf.Clamp(
            playerPosition.z - offset, playerPosition.z - offset, playerPosition.z - offset + 9));
        }
        else
        {
            animator.ResetTrigger("Run Forward");
            animator.SetTrigger("Idle");
        }
    }
}
