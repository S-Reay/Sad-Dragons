using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_CodeExecute : MonoBehaviour
{
    [SerializeField] private GameObject startingBlock;
    [SerializeField] private LayerMask codeBlockLayer;
    public List<GameObject> currentBlocks = new List<GameObject>();
    private void Awake()
    {
        startingBlock = GameObject.FindGameObjectWithTag("StartingBlock");
    }
    public void Execute()
    {
        ListBlocks();       //Detect which blocks are in a row and add them to the list
        if (SyntaxCheck())  //Determine if syntax is correct
        {
            Debug.Log("Code can run");
        }
        else
        {
            Debug.Log("Code cannot run");
        }
    }

    void ListBlocks()
    {
        currentBlocks.Clear();  //Clear the current blocks list
        currentBlocks.Add(startingBlock); // add the starting block

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

                    break;
                case "For":

                    break;
                case "Int":

                    break;
                case "Bool":

                    break;
                case "Is":

                    break;
                default:
                    break;
            }
        }
        return true;

    }
}
