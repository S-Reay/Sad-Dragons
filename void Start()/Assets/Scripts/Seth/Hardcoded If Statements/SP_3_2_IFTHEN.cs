using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IF DOOR IS FALSE
//THEN PLAYER IS FALL
public class SP_3_2_IFTHEN : MonoBehaviour
{
    public GameObject door;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(door.activeSelf);
        if (!door.activeSelf)
        {
            //Debug.Log("Test");
            player.GetComponent<SP_Player_GridDirectionalMove>().isFlying = false;
            player.GetComponentInChildren<Animator>().SetBool("EndFly", true);
        }
    }
}
