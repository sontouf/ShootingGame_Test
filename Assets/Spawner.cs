using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform[] spawnPoints;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }
    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab);
            enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
        }
    }
}
