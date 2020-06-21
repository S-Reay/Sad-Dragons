using UnityEngine;
using System.Collections;

public class SP_Player_CameraRotate : MonoBehaviour
{
    [Range(0, 20)]
    [SerializeField] float rotationSmoothness;

    private Quaternion rotateFrom;
    private Quaternion rotateTo;

    private bool isRotating = false;
   
    void Update()
    {
        if (Input.GetButtonDown("RotateLeft") && !isRotating)
        {
            rotateFrom = transform.rotation;
            rotateTo = transform.rotation * Quaternion.Euler(0, -90, 0);
            isRotating = true;
        }
        else if (Input.GetButtonDown("RotateRight") && !isRotating)
        {
            rotateFrom = transform.rotation;
            rotateTo = transform.rotation * Quaternion.Euler(0, 90, 0);
            isRotating = true;
        }
        if (isRotating)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotateTo, Time.deltaTime * rotationSmoothness);
        }
        if (Quaternion.Angle(transform.rotation, rotateTo) < 0.001f)
        {
            Debug.Log("Reached correct angle");
            isRotating = false;
        }
    }
}