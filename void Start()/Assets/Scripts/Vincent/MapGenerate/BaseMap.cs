using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMap : MonoBehaviour
{
    public bool rotateRandomly;
    public bool isMemorizingPosition;
    public GameObject floorTile;
    public Vector3 mapSize = new Vector3(10, 10, 1);

    private int[] rotationValue = new int[] {0,90,180,270};

    public void GenerateFloor()
    {
        if (isMemorizingPosition) {
            //if (transform.childCount == (mapSize.x * mapSize.y * mapSize.z))
            //{
            //    if (rotateRandomly)
            //    {
            //        for (int i = 0; i < transform.childCount; i++)
            //        {
            //            Transform tile = transform.GetChild(i);
            //            int rotation = rotationValue[Random.Range(0, rotationValue.Length - 1)];
            //            tile.localEulerAngles = new Vector3(tile.localEulerAngles.x, rotation, 0);
            //        }
            //    }
            //}
            if (rotateRandomly)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform tile = transform.GetChild(i);
                    int rotation = rotationValue[Random.Range(0, rotationValue.Length - 1)];
                    tile.localEulerAngles = new Vector3(tile.localEulerAngles.x, rotation, 0);
                }
            }
        }
        else
        {
            ClearMap();
            for (int x = 0; x < mapSize.x; x++)
            {
                for (int y = 0; y < mapSize.y; y++)
                {
                    for (int z = 0; z < mapSize.z; z++)
                    {
                        if (rotateRandomly)
                        {
                            GameObject tile = Instantiate(floorTile, this.transform);
                            tile.transform.localPosition = new Vector3(x, z, y);
                            int rotation = rotationValue[Random.Range(0, rotationValue.Length - 1)];
                            tile.transform.localEulerAngles = new Vector3(tile.transform.localEulerAngles.x, rotation, 0);
                        }
                        else
                        {
                            GameObject tile = Instantiate(floorTile, this.transform);
                            tile.transform.localPosition = new Vector3(x, z, y);
                        }

                    }
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
