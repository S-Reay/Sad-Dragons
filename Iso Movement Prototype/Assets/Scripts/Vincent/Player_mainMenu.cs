using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mainMenu : MonoBehaviour
{
    public float runSpeed;
    private float currentSpeed;

    private float turnSmoothVelocity;
    public float turnSmoothValue;

    private float forwardMovementSmoothVelocity;
    public float forwardMovementSmoothValue;

    public float rayDis = 1.5f;
    public LayerMask clickable;
    private bool isPicking;
    [SerializeField]
    private Transform currentPickedObject;

    Vector3 direction;
    Rigidbody rb;
    [SerializeField]
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("PickUp")) {
            direction = Vector3.zero;
        }
        else {
            direction = new Vector3(horizontal, 0, vertical).normalized;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDis, clickable)) {
            if (Input.GetMouseButtonDown(0)) {
                if (!isPicking)
                {
                    currentPickedObject = hit.transform;
                    currentPickedObject.SetParent(transform);
                    currentPickedObject.localPosition = new Vector3(0,1,0.8f);
                    isPicking = true;
                }
            }
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("WithObject")) {
            if (Input.GetMouseButtonDown(0)) {
                currentPickedObject.SetParent(null);
                currentPickedObject.transform.position = new Vector3(currentPickedObject.position.x, 0.5f, currentPickedObject.position.z);
                currentPickedObject = null;
                isPicking = false;
            }
        }

        anim.SetFloat("Moving",direction.magnitude,forwardMovementSmoothValue,Time.deltaTime);
        anim.SetBool("Picking",isPicking);
    }

    private void FixedUpdate()
    {
        if (direction.magnitude >= 0.1f)
        {
            float targetRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothValue);
            transform.rotation = Quaternion.Euler(0, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0, targetRotation, 0f) * Vector3.forward;
            float targetSpeed = runSpeed * direction.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref forwardMovementSmoothVelocity, forwardMovementSmoothValue);
            rb.MovePosition(transform.position + moveDir.normalized * currentSpeed * Time.fixedDeltaTime);
        }
    }

}
