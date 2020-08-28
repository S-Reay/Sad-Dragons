using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Player_Grab : MonoBehaviour
{
    public SP_Player_GridDirectionalMove moveScript;
    private Animator animator;

    private void Awake()
    {
        moveScript = GetComponent<SP_Player_GridDirectionalMove>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (!moveScript.isHolding)  //If the player is not holding anything
            {
                RaycastHit hit;
                if (Physics.Raycast(moveScript.centrePoint.position, transform.forward, out hit, 1))
                {
                    if (hit.transform.tag == "Pushable" || hit.transform.tag == "PushableRock")
                    {
                        Grab(hit.transform);
                    }
                }
            }
            else
            {
                Release();
            }

        }
    }

    void Grab(Transform block)
    {
        moveScript.heldBlock = block.GetComponent<SP_CodeBlock_Move>();    //Assign the specific block's script to heldBlock
        moveScript.heldBlock.isGrabbed = true;                             //Inform the block that it is being grabbed (I hope it doesn't mind)
        moveScript.heldBlock.gameObject.layer = 9;                         //Assigns the heldBlock to the held layer   //THIS SHOULD NOT BE HARDCODED (but oh well ¯\_(ツ)_/¯)
        moveScript.isHolding = true;

        animator.SetBool("Picking", true);
    }
    void Release()
    {
        moveScript.heldBlock.isGrabbed = false;
        moveScript.heldBlock.gameObject.layer = 8;                         //THIS SHOULD NOT BE HARDCODED (but it is)
        moveScript.isHolding = false;
        moveScript.heldBlock = null;

        animator.SetBool("Picking", false);
    }
}
