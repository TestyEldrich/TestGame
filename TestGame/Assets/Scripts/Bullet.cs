using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float collisionDamage;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            FloatingHealthBar healthBar = collision.gameObject.GetComponentInChildren<FloatingHealthBar>();
            Health health = collision.gameObject.GetComponent<Health>();
            health.Damage(collisionDamage);
            healthBar.UpdateHealthBar(health.currentHealth, health.maxHealth);

        }
        Destroy(gameObject);
    }
}
