using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    private float minDistance = 0;
    Vector3 aimDirection;

    private void Awake() {
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        minDistance = 0;
        foreach (GameObject gameObject in gameObjects) {
            float distance = Vector2.Distance(transform.position, gameObject.transform.position);
            if (distance < minDistance || minDistance == 0) {
                minDistance = distance;
                aimDirection = (gameObject.transform.position - transform.position).normalized;
            }
        }
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void LateUpdate() {
        
    }
}
