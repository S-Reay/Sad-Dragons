using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseMap))]
public class BaseMapEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        BaseMap f = target as BaseMap;

        if (GUILayout.Button("GenerateMap"))
        {
            f.GenerateFloor();
        }

    }

}
