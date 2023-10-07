using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class CollisionDamage : MonoBehaviour
{
    public float collisionDamage;
    public string collisionTag;
    public float pushForce;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == collisionTag) {
            Health health = collision.gameObject.GetComponent<Health>();
            health.Damage(collisionDamage);
            
        }
    }
}
