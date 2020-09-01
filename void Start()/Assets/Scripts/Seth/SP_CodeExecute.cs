﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_CodeExecute : MonoBehaviour
{
    [SerializeField] private GameObject startingBlock1;
    [SerializeField] private LayerMask codeBlockLayer;
    public List<GameObject> currentBlocks = new List<GameObject>();

    public List<GameObject> objectsToModify1 = new List<GameObject>();

    public GameObject startingBlockHighlight;

    public SP_2_2_IFTHEN IFTHEN22 = null;
    public SP_3_1_IFTHEN IFTHEN31 = null;

    private void Awake()
    {
        startingBlock1 = GameObject.FindGameObjectWithTag("StartingBlock");
        startingBlockHighlight = GameObject.FindGameObjectWithTag("Highlight");
        startingBlockHighlight.transform.position = startingBlock1.transform.position;
    }

    public void SwapStartingBlock(GameObject newStartingBlock)
    {
        startingBlock1.gameObject.tag = "InactiveStartingBlock";
        startingBlock1 = newStartingBlock;
        startingBlock1.gameObject.tag = "StartingBlock";
        startingBlockHighlight.transform.position = startingBlock1.transform.position;
    }

    public void Execute()
    {
        objectsToModify1.Clear();    //Clear any previously saved objects
        ListBlocks();               //Detect which blocks are in a row and add them to the list
        if (SyntaxCheck())      //Determine if syntax is correct
        {
            Debug.Log("Code can run");
        }
        else
        {
            Debug.Log("Code cannot run");
            return;
        }
        CheckObjectToModify();
        if (objectsToModify1.Count > 0)  //If there are any referenced objects
        {
           // Debug.Log("There are objects to modify");
            if (currentBlocks.Count > 1)                                            //If there are more than 1 blocks in the execution
            {
                if (currentBlocks[1].GetComponent<SP_CodeBlock_Info>().type == "Is") //If the starting block is followed by 'Is'
                {
                    //Debug.Log("Object is followed by IS");
                    if (currentBlocks[2].GetComponent<SP_CodeBlock_Info>().type == "Bool" ||
                        currentBlocks[2].GetComponent<SP_CodeBlock_Info>().type == "Fly" ||
                        currentBlocks[2].GetComponent<SP_CodeBlock_Info>().type == "Object")    //If 'is' is followed by Bool, Fly or Object
                    {
                        Debug.Log("IS is followed by valid block");
                        ModifyObjects(currentBlocks[2].GetComponent<SP_CodeBlock_Info>()); //Call ModifyObjects and feed it the modification codeblock
                    }
                }
            }
        }
    }

    void ListBlocks()
    {
        currentBlocks.Clear();  //Clear the current blocks list
        currentBlocks.Add(startingBlock1); // add the starting block

        bool moreBlocks = true;
        while (moreBlocks)
        {
            RaycastHit hit;
            if (Physics.Raycast(currentBlocks[currentBlocks.Count - 1].transform.position, Vector3.forward, out hit, 1, codeBlockLayer))
            {
                //Debug.Log("Next block is " + hit.transform.name);
                currentBlocks.Add(hit.transform.gameObject);
            }
            else
            {
                //Debug.Log("No more code blocks found");
                moreBlocks = false;
            }
        }
    }

    bool SyntaxCheck()
    {
        if (currentBlocks[currentBlocks.Count-1].GetComponent<SP_CodeBlock_Info>().type == "Operator" ||
            currentBlocks[currentBlocks.Count - 1].GetComponent<SP_CodeBlock_Info>().type == "Is")
        {
            Debug.Log("Code is incomplete");
            return false;
        }
        for (int checkingBlock = 0; checkingBlock + 1 < currentBlocks.Count; checkingBlock++)
        {
            switch (currentBlocks[checkingBlock].GetComponent<SP_CodeBlock_Info>().type)
            {
                case "Object":
                    if (currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Is")  //If the following block is correct
                    {
                        checkingBlock++;    //Move onto the next block
                    }
                    else
                    {
                        //HIGHLIGHT THIS BLOCK
                        return false;
                    }
                    break;
                case "Operator":
                    if (currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Int" ||
                        currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Bool")  //If the following block is correct
                    {
                        checkingBlock++;    //Move onto the next block
                    }
                    else
                    {
                        //HIGHLIGHT THIS BLOCK
                        return false;
                    }
                    break;
                case "If":
                    if (currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Int" ||
                        currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Bool" ||
                        currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Object")  //If the following block is correct
                    {
                        checkingBlock++;    //Move onto the next block
                    }
                    else
                    {
                        //HIGHLIGHT THIS BLOCK
                        return false;
                    }
                    break;
                case "For":
                    if (currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Int" ||
                        currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Bool" ||
                        currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Object")  //If the following block is correct
                    {
                        checkingBlock++;    //Move onto the next block
                    }
                    else
                    {
                        //HIGHLIGHT THIS BLOCK
                        return false;
                    }
                    break;
                case "Int":
                    if (currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Is" ||
                        currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Equals")  //If the following block is correct
                    {
                        checkingBlock++;    //Move onto the next block
                    }
                    else
                    {
                        //HIGHLIGHT THIS BLOCK
                        return false;
                    }
                    break;
                case "Bool":
                    if (currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Is" ||
                        currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Equals")  //If the following block is correct
                    {
                        checkingBlock++;    //Move onto the next block
                    }
                    else
                    {
                        //HIGHLIGHT THIS BLOCK
                        return false;
                    }
                    break;
                case "Is":
                    if (currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Int" ||
                        currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Bool" ||
                        currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Object" ||
                        currentBlocks[checkingBlock + 1].GetComponent<SP_CodeBlock_Info>().type == "Fly")  //If the following block is correct
                    {
                        checkingBlock++;    //Move onto the next block
                    }
                    else
                    {
                        //HIGHLIGHT THIS BLOCK
                        return false;
                    }
                    break;
                default:
                    break;
            }
        }
        return true;

    }

    void CheckObjectToModify()
    {
        if (startingBlock1.GetComponent<SP_CodeBlock_Info>().type == "Object")   //If the first code block is an object
        {
            foreach (GameObject referencedObject in GameObject.FindGameObjectsWithTag(startingBlock1.GetComponent<SP_CodeBlock_Info>().referencedObjectsTag))    //Find all the objects referenced by the code block
            {
                objectsToModify1.Add(referencedObject);                                                                                                          //And add them to the objecftsToModify list
            }
            if (startingBlock1.GetComponent<SP_CodeBlock_Info>().referencedObjectsTag2 != "") //If the code block has a second referencedObjectsTag
            {
                foreach (GameObject referencedObject in GameObject.FindGameObjectsWithTag(startingBlock1.GetComponent<SP_CodeBlock_Info>().referencedObjectsTag2))    //Find all the objects referenced by the code block
                {
                    objectsToModify1.Add(referencedObject);                                                                                                          //And add them to the objecftsToModify list
                }
            }
        }
    }

    void ModifyObjects(SP_CodeBlock_Info modifier)
    {
        switch (modifier.type)
        {
            case "Bool":
                foreach (GameObject parent in objectsToModify1)
                {
                    foreach (Transform child in parent.transform)
                    {
                        Debug.Log("Children are " + child.name);
                        child.gameObject.SetActive(modifier._bool);
                    }
                }

                break;
            case "Fly":
                //MAKE THE OBJECTS FLY OR FALL
                if (modifier._bool) //FOR A POSITIVE FLY
                {
                    foreach (GameObject parent in objectsToModify1)
                    {
                        foreach (Transform child in parent.transform)
                        {
                            Debug.Log("Children are " + child.name);

                            if (parent.tag == "Rock")
                            {
                                child.GetComponent<FloatingEffect>().enabled = true;
                                parent.tag = "PushableRock";
                                //parent.layer = 9;   //Assigns the heldBlock to the held layer   //THIS SHOULD NOT BE HARDCODED (but oh well ¯\_(ツ)_/¯)
                            }
                            else if (parent.tag == "Player")
                            {
                                //FLY ANIMATION
                                //ALLOW TO PASS OVER GAPS
                                parent.GetComponent<SP_Player_GridDirectionalMove>().isFlying = true;
                                parent.GetComponentInChildren<Animator>().SetTrigger("StartFly");
                            }

                        }
                    }
                }
                else                //FOR A NEGATIVE FLY (FALL)
                {
                    if (IFTHEN22 != null)
                    {
                        IFTHEN22.UpdateRockCount();
                    }
                    foreach (GameObject parent in objectsToModify1)
                    {
                        foreach (Transform child in parent.transform)
                        {
                            Debug.Log("Children are " + child.name);

                            if (parent.tag == "PushableRock")
                            {
                                child.GetComponent<FloatingEffect>().enabled = false;
                                parent.tag = "Rock";

                                RaycastHit hit;
                                if (Physics.Raycast(parent.transform.position, Vector3.down, out hit, 1))
                                {
                                    Debug.Log("Rock is sitting on " + hit.transform.name);
                                    if (IFTHEN22 != null)
                                    {
                                        IFTHEN22.UpdateRockCount();
                                    }
                                }
                                else
                                {
                                    Debug.Log("Rock: " + parent.name + " should fall");
                                    StartCoroutine(DropRock(parent));
                                    //Destroy(parent, 1f);
                                    if (IFTHEN22 != null)
                                    {
                                        IFTHEN22.UpdateRockCount();
                                    }
                                }
                            }
                            else if (parent.tag == "Player")
                            {
                                //Player Fall
                            }

                        }
                    }
                }
                break;
            case "Object":
                //CHANGE THE OBJECTS TO BE OTHER OBJECTS
                break;
            default:
                break;
        }
    }

    IEnumerator DropRock(GameObject rock)
    {
        Vector3 destination = rock.transform.position + Vector3.down * 5f;
        float elapsed = 0.0f;
        float duration = 3.0f;
        while (elapsed < duration)
        {
            rock.transform.position = Vector3.Lerp(rock.transform.position, destination, .1f);
            //rock.transform.position += Vector3.down * 0.01f;
            elapsed += Time.deltaTime;
        }
        if (elapsed > duration)
        {
            Destroy(rock);
        }
        yield return null;
    }
}
