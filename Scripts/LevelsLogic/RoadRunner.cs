using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRunner : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    // The safeZone helps to establish time before destroying a tile
    private float spawnZ = -6, tileLength = 6, safeZone = 9;
    private int tilesOnScreen = 7;
    private Transform playerTransform;
    private int count = 0;

    private List<GameObject> tiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < tilesOnScreen; i++)
        {
            InstantiateTile(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - tilesOnScreen * tileLength))
        {
            if (count == 6 && Level3Vars.total < 10)
            {
                InstantiateTile(1);
                count = 0;
            }
            else { 
                InstantiateTile(0);
                count++;
            }
            DeleteTile();
        }
    }

    private void InstantiateTile (int prefabIndex)
    {
        GameObject tile;
        tile = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        tile.transform.SetParent(transform);
        tile.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        tiles.Add(tile);
    }

    private void DeleteTile()
    {
        Destroy(tiles[0]);
        tiles.RemoveAt(0);
    }
}
