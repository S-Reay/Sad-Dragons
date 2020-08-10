using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMap : MonoBehaviour
{
    public GameObject floorTile;
    public Vector3 mapSize = new Vector3(10, 10, 1);

    public void GenerateFloor()
    {
        ClearMap();
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                for (int z = 0; z < mapSize.z; z++)
                {
                    GameObject tile = Instantiate(floorTile,this.transform);
                    tile.transform.localPosition = new Vector3(x, z, y);
                }
            }
        }
    }

    public void ClearMap()
    {
        while (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
    }

}
