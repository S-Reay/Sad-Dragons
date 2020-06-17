using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GridMove : MonoBehaviour
{
    public Transform farNorthCheck;
    public Transform farSouthCheck;
    public Transform farEastCheck;
    public Transform farWestCheck;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))       //Right
        {
            Debug.Log("Right");
            MoveEast();
        }
        else if (Input.GetKeyDown(KeyCode.A)) //Left
        {
            Debug.Log("Left");
            MoveWest();
        }
        else if (Input.GetKeyDown(KeyCode.W))    //Up
        {
            Debug.Log("Up");
            MoveNorth();
        }
        else if (Input.GetKeyDown(KeyCode.S))   //Down
        {
            Debug.Log("Down");
            MoveSouth();
        }
    }
    void MoveNorth()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1))
        {
            if (hit.transform.tag == "Obstacle")
            {
                //Path is obstructed
            }
            else if (hit.transform.tag == "Pushable")
            {
                //Object can be pushed
                Collider[] hitColliders = Physics.OverlapSphere(farNorthCheck.position, 0.2f);
                if (hitColliders.Length == 0)
                {
                    //Object's path is clear
                    hit.transform.position += Vector3.forward;
                    transform.position += Vector3.forward;
                }
                else
                {
                    //Object's path is blocked
                    Debug.Log("Pushable path blocked");
                }
            }
        }
        else
        {
            //Path is clear
            transform.position += Vector3.forward;
        }
    }
    void MoveSouth()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 1))
        {
            if (hit.transform.tag == "Obstacle")
            {
                //Path is obstructed
            }
            else if (hit.transform.tag == "Pushable")
            {
                //Object can be pushed
                Collider[] hitColliders = Physics.OverlapSphere(farSouthCheck.position, 0.2f);
                if (hitColliders.Length == 0)
                {
                    //Object's path is clear
                    hit.transform.position += Vector3.back;
                    transform.position += Vector3.back;
                }
                else
                {
                    //Object's path is blocked
                    Debug.Log("Pushable path blocked");
                }
            }
        }
        else
        {
            //Path is clear
            transform.position += Vector3.back;
        }
    }
    void MoveEast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1))
        {
            if (hit.transform.tag == "Obstacle")
            {
                //Path is obstructed
            }
            else if (hit.transform.tag == "Pushable")
            {
                //Object can be pushed
                Collider[] hitColliders = Physics.OverlapSphere(farEastCheck.position, 0.2f);
                if (hitColliders.Length == 0)
                {
                    //Object's path is clear
                    hit.transform.position += Vector3.right;
                    transform.position += Vector3.right;
                }
                else
                {
                    //Object's path is blocked
                    Debug.Log("Pushable path blocked");
                }
            }
        }
        else
        {
            //Path is clear
            transform.position += Vector3.right;
        }
    }
    void MoveWest()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1))
        {
            if (hit.transform.tag == "Obstacle")
            {
                //Path is obstructed
            }
            else if (hit.transform.tag == "Pushable")
            {
                //Object can be pushed
                Collider[] hitColliders = Physics.OverlapSphere(farWestCheck.position, 0.2f);
                if (hitColliders.Length == 0)
                {
                    //Object's path is clear
                    hit.transform.position += Vector3.left;
                    transform.position += Vector3.left;
                }
                else
                {
                    //Object's path is blocked
                    Debug.Log("Pushable path blocked");
                }
            }
        }
        else
        {
            //Path is clear
            transform.position += Vector3.left;
        }
    }
}
