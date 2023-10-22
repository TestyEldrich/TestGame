using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public GameObject dropLoot;

    public void Damage(float damageValue) {
        currentHealth -= damageValue;
        if(currentHealth <= 0) {
            if(gameObject.tag == "Enemy") {
                GameObject drop = Instantiate(dropLoot);
                drop.transform.localPosition = gameObject.transform.position;
            }
            Destroy(gameObject);
        }
    }
}
