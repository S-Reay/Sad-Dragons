using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_ExitBlock_BoundaryDisable : MonoBehaviour
{
    [SerializeField] GameObject boundary;
    private void Start()
    {
        boundary.SetActive(false);
    }
}
