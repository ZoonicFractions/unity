using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour
{

    public float speed = 3f;
    public float rotationSpeed = 2f;
    public Transform pathParent;
    Transform targetPoint;
    int index;
    private Quaternion lookRotation;
    private Vector3 direction;


    void OnDrawGizmos()
    {
        Vector3 from;
        Vector3 to;

        for (int a = 0; a < pathParent.childCount; a++)
        {
            from = pathParent.GetChild(a).position;
            to = pathParent.GetChild((a + 1) % pathParent.childCount).position;
            Gizmos.color = new Color(1, 0, 0);
            Gizmos.DrawLine(from, to);
        }
    }
    void Start()
    {
        index = 0;
        targetPoint = pathParent.GetChild(index);
    }

    // Update is called once per frame
    void Update()
    {
        var direction = (targetPoint.position - transform.position).normalized;
        lookRotation = Quaternion.LookRotation(direction);

        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            index++;
            index %= pathParent.childCount;
            targetPoint = pathParent.GetChild(index);
        }
    }
}
