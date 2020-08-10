using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMcheck : MonoBehaviour
{
    public GameObject AM;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<audiomaneger>())
            return;
        else Instantiate(AM, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
