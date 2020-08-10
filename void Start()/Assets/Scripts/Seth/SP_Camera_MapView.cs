using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Camera_MapView : MonoBehaviour
{
    [SerializeField]Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Map"))                                     //When the map button is pressed
        {
            animator.SetBool("isMapView", !animator.GetBool("isMapView"));  //Invert the isMapView boolean in the camera animator
        }
    }
}
