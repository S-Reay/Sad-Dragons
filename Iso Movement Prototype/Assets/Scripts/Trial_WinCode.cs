using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial_WinCode : MonoBehaviour
{
    public GameObject trialCodeBlock1;
    public GameObject trialCodeBlock2;
    public GameObject trialCodeBlock3;
    public GameObject trialVoidBlock;

    // for the position of the start of code
    private float trialCodeStartx;
    private float trialCodeStarty;
    private float trialCodeStartz;

    // for the position of the middle of code
    private float tCMx;
    private float tCMy;
    private float tCMz;

    // for the position of the end of code
    private float tCEx;
    private float tCEy;
    private float tCEz;

    // Start is called before the first frame update
    void Start()
    {
        trialVoidBlock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // this is setting up the start of the code, this is just a brute forced way to do it. Hopefully we will have a better way of doing this for a final project
        trialCodeStartx = trialCodeBlock1.transform.position.x;
        trialCodeStarty = trialCodeBlock1.transform.position.y;
        trialCodeStartz = trialCodeBlock1.transform.position.z;

        tCMx = trialCodeBlock2.transform.position.x;
        tCMy = trialCodeBlock2.transform.position.y;
        tCMz = trialCodeBlock2.transform.position.z;

        tCEx = trialCodeBlock3.transform.position.x;
        tCEy = trialCodeBlock3.transform.position.y;
        tCEz = trialCodeBlock3.transform.position.z;

        //This is to set up the string of code so it registers that the code is in a line and thus can create the exit / void tile

        if (trialCodeStartx == tCMx && trialCodeStartx == tCEx && trialCodeStartz == tCMz - 1 && tCMz == tCEz - 1)
        {
            trialVoidBlock.SetActive(true);
        }
        else
        {
            trialVoidBlock.SetActive(false);
        }

    }
}
