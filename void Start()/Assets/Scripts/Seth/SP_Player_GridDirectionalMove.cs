using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Player_GridDirectionalMove : MonoBehaviour
{
    [Range(0, 3)]
    [Tooltip("Determines how the player moves based on the camera's direction")]
    public int cameraCorner = 0;
    [SerializeField] bool isHolding = false;
    [SerializeField] Transform centrePoint;

    [SerializeField] LayerMask triggerLayerMask;
    private int noTriggerLayer;

    [SerializeField] int stepDistance = 1; //How far the player moves in one click

    private void Awake()
    {
        noTriggerLayer = ~triggerLayerMask; //The noTriggerLayer refers to every layer that isn't the triggerLayer (wow, what a surprise!)
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
                Debug.Log("0");
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case 1:
                Debug.Log("1");
                transform.eulerAngles = new Vector3(0, 90, 0);
                break;
            case 2:
                Debug.Log("2");
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 3:
                Debug.Log("3");
                transform.eulerAngles = new Vector3(0, 270, 0);
                break;
            default:
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
    }
}
