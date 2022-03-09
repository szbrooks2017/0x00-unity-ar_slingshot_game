using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TargetController : MonoBehaviour
{
    public float wanderRadius;
    private NavMeshAgent target;
    private float waitTime = 1.0f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void OnEnable()
    {
        target = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            timer -= waitTime;
            // move agent here.
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            target.SetDestination(newPos);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
}
