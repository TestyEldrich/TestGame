using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Android;

public class CollisionDamage : MonoBehaviour
{
    public float collisionDamage;
    public string collisionTag;
    public float pushForce, delay;
    private Rigidbody2D rB2d;

    public UnityEvent OnBegin, OnDone;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == collisionTag) {
            FloatingHealthBar healthBar = collision.gameObject.GetComponentInChildren<FloatingHealthBar>();
            Health health = collision.gameObject.GetComponent<Health>();
            health.Damage(collisionDamage);
            healthBar.UpdateHealthBar(health.currentHealth, health.maxHealth);

            StopAllCoroutines();
            OnBegin?.Invoke();
            rB2d = collision.gameObject.GetComponent<Rigidbody2D>();
            var direction = transform.position - collision.transform.position;
            direction.Normalize();

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-direction * pushForce, ForceMode2D.Impulse);
            StartCoroutine(Reset());
        }
    }

    private IEnumerator Reset() {
        yield return new WaitForSeconds(delay);
        if(rB2d != null) {
            rB2d.velocity = Vector3.zero;
        }
        OnBegin?.Invoke();
    }
}
