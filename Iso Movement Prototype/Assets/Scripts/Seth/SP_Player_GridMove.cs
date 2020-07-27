using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Player_GridMove : MonoBehaviour
{
    //[SerializeField] Transform farNorthCheck;
    //[SerializeField] Transform farSouthCheck;
    //[SerializeField] Transform farEastCheck;      These aren't in use, but I've kept them in case they are needed later
    //[SerializeField] Transform farWestCheck;
    [SerializeField] Transform centrePoint;

    [Space]
    [Tooltip("North\nSouth\nEast\nWest")]
    [SerializeField] Transform[] nearChecks;
    [Space]
    [SerializeField] LayerMask clickLayerMask;
    [SerializeField] LayerMask heldLayerMask;
    [SerializeField] LayerMask triggerLayerMask;

    private int noGrabLayer;
    private int clickableLayer;
    private int noTriggerLayer;

    public bool isGrabbing = false;
    public SP_CodeBlock_Grab heldBlock;
    private SP_CodeExecute codeExecute;

    [Range(0, 3)]
    [Tooltip("Determines how the player moves based on the camera's direction")]
    public int cameraCorner = 0;

    private void Awake()
    {
        noGrabLayer = ~heldLayerMask;
        noTriggerLayer = ~triggerLayerMask;
        clickableLayer = clickLayerMask | heldLayerMask;
        codeExecute = GetComponent<SP_CodeExecute>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DirectionCheck(0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            DirectionCheck(1);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            DirectionCheck(2);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            DirectionCheck(3);
        }

        if (Input.GetMouseButtonDown(0))                                    //If the player clicks left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //Cast a ray from the camera to where their cursor is
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, clickableLayer))        //If the ray hits something
            {
                if (hit.transform.tag == "Pushable")                        //If it hits something "Pushable"
                {
                    if (!isGrabbing)
                    {
                        CheckAdjacent(hit.transform);                       //Check to see if that object is adjacent
                    }
                    else
                    {
                        if (hit.transform == heldBlock.transform)
                        {
                            Release();
                        }
                    }

                }
                else if (hit.transform.tag == "RunButton")                  //If the player clicked the run button
                {
                    codeExecute.Execute();                                  //Call the codeExecute script
                }
            }
        }
    }

    void DirectionCheck(int dir)
    {
        //These nested switch statements are poor practice, but I can't think of an alternateive :(
        switch (dir)
        {
            case 0:     //D
                switch (cameraCorner)
                {
                    case 0:     //East
                        if (isGrabbing)                         //If the player is grabbing a block
                        {
                            if (heldBlock.BlockMove("East"))    //If the block is clear to move
                            {
                                PushEast();
                            }
                        }
                        else
                        {
                            MoveEast();
                        }
                        break;
                    case 1:     //South
                        if (isGrabbing)
                        {
                            if (heldBlock.BlockMove("South"))
                            {
                                PushSouth();
                            }
                        }
                        else
                        {
                            MoveSouth();
                        }
                        break;
                    case 2:     //West
                        if (isGrabbing)
                        {
                            if (heldBlock.BlockMove("West"))
                            {
                                PushWest();
                            }
                        }
                        else
                        {
                            MoveWest();
                        }
                        break;
                    case 3:     //North
                        if (isGrabbing)
                        {
                            if (heldBlock.BlockMove("North"))
                            {
                                PushNorth();
                            }
                        }
                        else
                        {
                            MoveNorth();
                        }
                        break;
                    default:
                        break;
                }
                break;
            case 1:     //A
                switch (cameraCorner)
                {
                    case 0:     //West
                        if (isGrabbing)
                        {
                            if (heldBlock.BlockMove("West"))
                            {
                                PushWest();
                            }
                        }
                        else
                        {
                            MoveWest();
                        }
                        break;
                    case 1:     //North
                        if (isGrabbing)
                        {
                            if (heldBlock.BlockMove("North"))
                            {
                                PushNorth();
                            }
                        }
                        else
                        {
                            MoveNorth();
                        }
                        break;
                    case 2:     //East
                        if (isGrabbing)                         //If the player is grabbing a block
                        {
                            if (heldBlock.BlockMove("East"))    //If the block is clear to move
                            {
                                PushEast();
                            }
                        }
                        else
                        {
                            MoveEast();
                        }
                        break;
                    case 3:     //South
                        if (isGrabbing)
                        {
                            if (heldBlock.BlockMove("South"))
                            {
                                PushSouth();
                            }
                        }
                        else
                        {
                            MoveSouth();
                        }
                        break;
                    default:
                        break;
                }
                break;
            case 2:     //W
                switch (cameraCorner)
                {
                    case 0:     //North
                        if (isGrabbing)
                        {
                            if (heldBlock.BlockMove("North"))
                            {
                                PushNorth();
                            }
                        }
                        else
                        {
                            MoveNorth();
                        }
                        break;
                    case 1:     //East
                        if (isGrabbing)                         //If the player is grabbing a block
                        {
                            if (heldBlock.BlockMove("East"))    //If the block is clear to move
                            {
                                PushEast();
                            }
                        }
                        else
                        {
                            MoveEast();
                        }
                        break;
                    case 2:     //South
                        if (isGrabbing)
                        {
                            if (heldBlock.BlockMove("South"))
                            {
                                PushSouth();
                            }
                        }
                        else
                        {
                            MoveSouth();
                        }
                        break;
                    case 3:     //West
                        if (isGrabbing)
                        {
                            if (heldBlock.BlockMove("West"))
                            {
                                PushWest();
                            }
                        }
                        else
                        {
                            MoveWest();
                        }
                        break;
                    default:
                        break;
                }
                break;
            case 3:     //S
                switch (cameraCorner)
                {
                    case 0:     //South
                        if (isGrabbing)
                        {
                            if (heldBlock.BlockMove("South"))
                            {
                                PushSouth();
                            }
                        }
                        else
                        {
                            MoveSouth();
                        }
                        break;
                    case 1:     //West
                        if (isGrabbing)
                        {
                            if (heldBlock.BlockMove("West"))
                            {
                                PushWest();
                            }
                        }
                        else
                        {
                            MoveWest();
                        }
                        break;
                    case 2:     //North
                        if (isGrabbing)
                        {
                            if (heldBlock.BlockMove("North"))
                            {
                                PushNorth();
                            }
                        }
                        else
                        {
                            MoveNorth();
                        }
                        break;
                    case 3:     //East
                        if (isGrabbing)                         //If the player is grabbing a block
                        {
                            if (heldBlock.BlockMove("East"))    //If the block is clear to move
                            {
                                PushEast();
                            }
                        }
                        else
                        {
                            MoveEast();
                        }
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    #region Movement
    void MoveNorth()
    {
        if (!Physics.Raycast(centrePoint.position, transform.TransformDirection(Vector3.forward), 1, noTriggerLayer))
        {
            //Path is clear
            transform.position += Vector3.forward;
        }
    }
    void MoveSouth()
    {
        if (!Physics.Raycast(centrePoint.position, transform.TransformDirection(Vector3.back), 1, noTriggerLayer))
        {
            //Path is clear
            transform.position += Vector3.back;
        }
    }
    void MoveEast()
    {
        if (!Physics.Raycast(centrePoint.position, transform.TransformDirection(Vector3.right), 1, noTriggerLayer))
        {
            //Path is clear
            transform.position += Vector3.right;
        }
    }
    void MoveWest()
    {
        if (!Physics.Raycast(centrePoint.position, transform.TransformDirection(Vector3.left), 1, noTriggerLayer))
        {
            //Path is clear
            transform.position += Vector3.left;
        }
    }
    #endregion

    #region Pushing
    void PushNorth()
    {
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 1, noGrabLayer))
        {
            //Path is clear
            transform.position += Vector3.forward;
            heldBlock.transform.position += Vector3.forward;
        }
    }
    void PushSouth()
    {
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), 1, noGrabLayer))
        {
            //Path is clear
            transform.position += Vector3.back;
            heldBlock.transform.position += Vector3.back;
        }
    }
    void PushEast()
    {
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), 1, noGrabLayer))
        {
            //Path is clear
            transform.position += Vector3.right;
            heldBlock.transform.position += Vector3.right;
        }
    }
    void PushWest()
    {
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), 1, noGrabLayer))
        {
            //Path is clear
            transform.position += Vector3.left;
            heldBlock.transform.position += Vector3.left;
        }
    }
    #endregion

    void CheckAdjacent(Transform clicked)
    {
        foreach (Transform check in nearChecks)
        {
            Collider[] hitColliders = Physics.OverlapSphere(check.position, 0.2f);  //Creates an array for each of the 4 'nearCheck' points
            if (hitColliders.Length == 0)
            {
                //No adjacent object in this space
            }
            else if (hitColliders.Length == 1)
            {
                //1 adjacent object in this space
                if (hitColliders[0].transform == clicked)   //If this object is that one that was clicked
                {
                    //Grab the object
                    Debug.Log("Player grabbed " + hitColliders[0].name);
                    isGrabbing = true;
                    Grab(hitColliders[0].transform);            //Call Grab();
                }

            }
            else
            {
                //More than one object detected in a single grid space
                Debug.LogError("More than one adjacent object at " + check.name);
            }
        }
    }

    void Grab(Transform block)
    {
        heldBlock = block.GetComponent<SP_CodeBlock_Grab>();    //Assign the specific block's script to heldBlock
        heldBlock.isGrabbed = true;                             //Inform the block that it is being grabbed (I hope it doesn't mind)
        heldBlock.gameObject.layer = 9;                         //Assigns the heldBlock to the held layer   //THIS SHOULD NOT BE HARDCODED (but oh well ¯\_(ツ)_/¯)
    }

    void Release()
    {
        heldBlock.isGrabbed = false;
        heldBlock.gameObject.layer = 8;                         //THIS SHOULD NOT BE HARDCODED (but it is)
        isGrabbing = false;
        heldBlock = null;
    }
}