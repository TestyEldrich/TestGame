using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private float xPos;
    private float yPos;
    private int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop() {
        while (enemyCount < 3) {
            xPos = Random.Range(-36, 32);
            yPos = Random.Range(-33, 26);
            Instantiate(enemy, new Vector3(xPos, yPos, 0), Quaternion.identity);
            yield return new WaitForSeconds(2);
            enemyCount++;
        }
    }
}
