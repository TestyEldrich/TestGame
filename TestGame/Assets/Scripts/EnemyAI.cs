using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float followDistance;
    [SerializeField]
    float rotateSpeed;

    NavMeshAgent agent;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        if (distance < followDistance) {
            if (direction.x < 0) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * rotateSpeed);
            }
            else if (direction.x > 0) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotateSpeed);
            }
            agent.SetDestination(target.position);
        }
    }
}
