using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public bool canRotate;
    public float rotateSpeed = 75;
    public float power = 0.2f;
    public float speed = 3f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(speed * Time.time) * power, transform.position.z);

        if (canRotate) {
            transform.Rotate(0,rotateSpeed * Time.deltaTime,0,Space.World);
        }
    }
}
