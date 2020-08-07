using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_CodeBlock_Info : MonoBehaviour
{
    [Header("TYPE CAN BE: Object, Operator, Int, Bool, If, For, Is, Equals, Fly")]
    public string type;
    public string referencedObjectsTag;
    public bool _bool;

    private void Awake()
    {
        if (type != "Object")               //If this code block is not an object
        {
            referencedObjectsTag = null;    //It does not reference any gameObjects via tag
        }
    }
}
