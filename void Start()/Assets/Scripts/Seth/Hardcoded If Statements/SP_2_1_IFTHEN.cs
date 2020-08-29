using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_2_1_IFTHEN : MonoBehaviour
{
    [SerializeField]GameObject door;
    [SerializeField] GameObject player;
    private bool isFlying = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (!door.activeSelf && !isFlying)
        {
            player.GetComponent<SP_Player_GridDirectionalMove>().isFlying = true;
            player.GetComponentInChildren<Animator>().SetTrigger("StartFly");
            isFlying = true;
        }
    }
}
