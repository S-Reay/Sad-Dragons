using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodingBlockEdgeColor : MonoBehaviour
{
    private MeshRenderer blockRenender;
    public Color32 originalColor = new Color32(84,84,84,255);
    public Color32 newColor = new Color32(5,156,226,255);
    public bool isConnected;
    public float twinkleSpeed = 2f;
    public Vector2 twinkleRange = new Vector2(0,0.75f);


    void Start()
    {
        blockRenender = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (!isConnected)
        {
            float t = Mathf.Sin(twinkleSpeed * Time.time) * twinkleRange.magnitude;
            blockRenender.material.color = Color.Lerp(originalColor, newColor, t);
        }
        else {
            blockRenender.material.color = newColor;
        }
    }
}
