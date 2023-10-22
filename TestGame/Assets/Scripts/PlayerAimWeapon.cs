using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce;
    public Transform firePoint;
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

        Vector3 localScale = Vector3.one;
        if(angle > 90 || angle < -90) {
            localScale.y = -1f;
        }
        else {
            localScale.y = +1f;
        }
        aimTransform.localScale = localScale;
    }

    public void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
