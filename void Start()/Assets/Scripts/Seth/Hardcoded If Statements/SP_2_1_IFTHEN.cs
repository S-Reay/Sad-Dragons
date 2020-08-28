using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_2_1_IFTHEN : MonoBehaviour
{
    [SerializeField]GameObject door;
    [SerializeField] GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        if (!door.activeSelf)
        {
            player.GetComponent<SP_Player_GridDirectionalMove>().isFlying = true;
            player.GetComponentInChildren<Animator>().SetTrigger("StartFly");
        }
    }
}
