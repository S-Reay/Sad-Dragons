using UnityEngine;
using System.Collections;

public class SP_Player_CameraRotate : MonoBehaviour
{
    [Range(0, 20)]
    [SerializeField] float rotationSmoothness;

    private Quaternion rotateFrom;
    private Quaternion rotateTo;

    private bool isRotating = false;

    public SP_Player_GridDirectionalMove moveScript;

    private void Awake()
    {
        moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<SP_Player_GridDirectionalMove>();
    }
    void Update()
    {
        if (Input.GetButtonDown("RotateLeft") && !isRotating)
        {
            rotateFrom = transform.rotation;
            rotateTo = transform.rotation * Quaternion.Euler(0, -90, 0);
            isRotating = true;
            if (moveScript.cameraCorner >= 1 && moveScript.cameraCorner <= 3)
            {
                moveScript.cameraCorner--;
            }
            else
            {
                moveScript.cameraCorner = 3;
            }

        }
        else if (Input.GetButtonDown("RotateRight") && !isRotating)
        {
            rotateFrom = transform.rotation;
            rotateTo = transform.rotation * Quaternion.Euler(0, 90, 0);
            isRotating = true;
            if (moveScript.cameraCorner >= 0 && moveScript.cameraCorner <= 2)
            {
                moveScript.cameraCorner++;
            }
            else
            {
                moveScript.cameraCorner = 0;
            }
        }
        if (isRotating)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotateTo, Time.deltaTime * rotationSmoothness);
        }
        if (Quaternion.Angle(transform.rotation, rotateTo) < 0.001f)
        {
            isRotating = false;
        }
    }
}