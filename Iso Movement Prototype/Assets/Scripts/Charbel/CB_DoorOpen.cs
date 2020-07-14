using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CB_DoorOpen : MonoBehaviour
{
    public bool play = false;

    public int DoorToOpen = 3;

    public Animation DoorSlide;

    public GameObject GreenBlock;
    // Start is called before the first frame update
    void Start()
    {
        play = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GreenBlock)

        {
            GreenBlock = GameObject.FindWithTag("GreenBlock");

            DoorToOpen = 3;


            if (DoorToOpen == 3)

            {
                Animation Ani = gameObject.GetComponent(typeof(Animation)) as Animation;

                if(Ani == true)
                {
                    DoorSlide.Play("Slide");
                }
            }

        }
    }
}

