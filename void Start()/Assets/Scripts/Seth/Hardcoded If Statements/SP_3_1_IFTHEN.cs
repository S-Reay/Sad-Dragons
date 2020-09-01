using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IF DOOR IS FALSE
//THEN ROCK IS TRUE

//IF DOOR IS TRUE
//THEN ROCK IS FALSE

public class SP_3_1_IFTHEN : MonoBehaviour
{
    public List<GameObject> rocks = new List<GameObject>();
    public GameObject door;

    public void Update()
    {
        foreach (GameObject rock in rocks)
        {
            rock.gameObject.SetActive(!door.activeSelf);    //Set each rock to the opposite active state as door
        }
    }
}
