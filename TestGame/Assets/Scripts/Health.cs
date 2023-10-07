using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public void Damage(float damageValue) {
        currentHealth -= damageValue;
        if(currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
