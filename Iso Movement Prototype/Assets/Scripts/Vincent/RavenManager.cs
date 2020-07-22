using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenManager : MonoBehaviour
{
    public List<AI_Raven> ravens;
    public List<Transform> landingPoints;

    private void Update()
    {
        for (int i = 0; i < ravens.Count; i++)
        {
            if (ravens[i].state == StateBehaviour.FindLandingPoint) {
                if (ravens[i].landingPoint == null) {
                    int randomNumber = Random.Range(0,landingPoints.Count);
                    ravens[i].landingPoint = landingPoints[randomNumber];
                    break;
                }
            }
        }
    }
}
