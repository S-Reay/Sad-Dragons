using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Player_GridDirectionalMove : MonoBehaviour
{
    [Range(0, 3)]
    [Tooltip("Determines how the player moves based on the camera's direction")]
    public int cameraCorner = 0;
    public bool isHolding = false;
    public Transform centrePoint;

    [SerializeField] LayerMask triggerLayerMask;
    private int noTriggerLayer;
    [SerializeField] LayerMask heldBlockLayerMask;
    private int noHeldBlockLayer;

    public SP_CodeBlock_Move heldBlock = null;

    [SerializeField] int stepDistance = 1; //How far the player moves in one click

    private void Awake()
    {
        noTriggerLayer = ~triggerLayerMask;     //The noTriggerLayer refers to every layer that isn't the triggerLayer (wow, what a surprise!)
        noHeldBlockLayer = ~heldBlockLayerMask; //I'll give you 3 guesses of what noHeldBlockLayer is... (everything except the heldBlockLayer)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isHolding)
            {
                Push(WorldDirection(0));
            }
            else
            {
                Move(WorldDirection(0));
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (isHolding)
            {
                Push(WorldDirection(1));
            }
            else
            {
                Move(WorldDirection(1));
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (isHolding)
            {
                Push(WorldDirection(2));
            }
            else
            {
                Move(WorldDirection(2));
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (isHolding)
            {
                Push(WorldDirection(3));
            }
            else
            {
                Move(WorldDirection(3));
            }
        }
    }

    int WorldDirection(int keyDir)
    {
        return (keyDir + cameraCorner) % 4;
    }

    void Move(int worldDir)
    {
        //Rotate the player to face the correct direction
        switch (worldDir)
        {
            case 0:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case 1:
                transform.eulerAngles = new Vector3(0, 90, 0);
                break;
            case 2:
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 3:
                transform.eulerAngles = new Vector3(0, 270, 0);
                break;
            default:
                Debug.LogError("Invalid worldDir in Move()");
                break;
        }

        //Check the space in front of the player
        if (!Physics.Raycast(centrePoint.position, transform.TransformDirection(Vector3.forward), 1, noTriggerLayer))
        {
            //Path is clear
            transform.position += transform.forward;
        }

    }

    void Push(int worldDir)
    {
        Debug.Log("Push Towards" + worldDir.ToString());
        if (!heldBlock.BlockMove(worldDir)) //Check if something is blocking the heldBlock
        {
            return;
        }
        switch (worldDir)                   //Check if something is blocking the player
        {
            case 0://North
                if (!Physics.Raycast(centrePoint.position, Vector3.forward, 1, noHeldBlockLayer))
                {
                    //Path is clear
                    transform.position += Vector3.forward;
                    heldBlock.transform.position += Vector3.forward;
                }
                break;
            case 2://South
                if (!Physics.Raycast(centrePoint.position, Vector3.back, 1, noHeldBlockLayer))
                {
                    //Path is clear
                    transform.position += Vector3.back;
                    heldBlock.transform.position += Vector3.back;
                }
                break;
            case 1://East
                if (!Physics.Raycast(centrePoint.position, Vector3.right, 1, noHeldBlockLayer))
                {
                    //Path is clear
                    transform.position += Vector3.right;
                    heldBlock.transform.position += Vector3.right;
                }
                break;
            case 3://West
                if (!Physics.Raycast(centrePoint.position, Vector3.left, 1, noHeldBlockLayer))
                {
                    //Path is clear
                    transform.position += Vector3.left;
                    heldBlock.transform.position += Vector3.left;
                }
                break;
            default:
                Debug.LogError("Invalid direction in Push()");
                break;
        }
    }
}
