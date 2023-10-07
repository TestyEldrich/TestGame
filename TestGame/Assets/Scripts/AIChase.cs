using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChase : MonoBehaviour
{
    public GameObject player;
    public float mobSpeed;
    public float followDistance;
    public float rotateSpeed;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance < followDistance) {
            if (direction.x < 0) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,180,0), Time.deltaTime * rotateSpeed);
            }else if(direction.x > 0) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotateSpeed);
            }
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, mobSpeed * Time.deltaTime);
        }
    }
}
