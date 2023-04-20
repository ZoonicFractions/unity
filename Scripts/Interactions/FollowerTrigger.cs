using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerTrigger : MonoBehaviour
{
    public GameObject follower;
    public GameObject followerTarget;

    Vector3 posTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posTarget = followerTarget.transform.position;

        follower.transform.position = new Vector3(followerTarget.transform.position.x, followerTarget.transform.position.y + 0.5f, followerTarget.transform.position.z + 0.1f);
    }
}
