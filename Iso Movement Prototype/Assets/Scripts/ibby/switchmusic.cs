using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchmusic : MonoBehaviour
{
    public AudioClip newtrack;
    private audiomaneger theAM;
    void Start()
    {
        theAM = FindObjectOfType<audiomaneger>();
        if(newtrack != null)
        theAM.ChangeBGM(newtrack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
