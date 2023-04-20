using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracDisplayRunner : MonoBehaviour
{
    public Transform fence;
    public Transform img, num, den;
    private const float NUM_Y = 1.25f, DEN_Y = 0.75f, IMG_Y = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        num.position = new Vector3(fence.position.x, NUM_Y, fence.position.z);
        den.position = new Vector3(fence.position.x, DEN_Y, fence.position.z);
        img.position = new Vector3(fence.position.x, IMG_Y, fence.position.z);
    }
}
