using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow3 : MonoBehaviour
{
    public Transform tileObj;
    private Vector3 nextTile;
    const float POS_INCREMENT = 19;
    // Start is called before the first frame update
    void Start()
    {
        nextTile = tileObj.position;
        StartCoroutine(spawnTile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);
        Instantiate(tileObj, nextTile, tileObj.rotation);
        nextTile.x += POS_INCREMENT;
        StartCoroutine(spawnTile());
    }

}
