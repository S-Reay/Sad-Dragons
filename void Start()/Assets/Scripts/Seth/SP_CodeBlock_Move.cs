using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_CodeBlock_Move : MonoBehaviour
{
    public bool isGrabbed = false;
    int nonPlayerLayer;
    [SerializeField] LayerMask playerLayerMask;
    private void Awake()
    {
        nonPlayerLayer = ~playerLayerMask;
    }
    public bool BlockMove(int dir)
    {
        switch (dir)
        {
            case 0://North
                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 1, nonPlayerLayer))
                {
                    //Path is clear
                    return true;
                }
                break;
            case 2://South
                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), 1, nonPlayerLayer))
                {
                    //Path is clear
                    return true;
                }
                break;
            case 1://East
                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), 1, nonPlayerLayer))
                {
                    //Path is clear
                    return true;
                }
                break;
            case 3://West
                if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), 1, nonPlayerLayer))
                {
                    //Path is clear
                    return true;
                }
                break;
            default:
                Debug.LogError("Invalid direction in BlockMove()");
                break;
        }
        return false;
    }
}
