using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("Максимальное количество врагов, которые могут быть одновременно в игре")]
    [SerializeField] private int maxEnemies = 22;

    [Tooltip("Префабы врагов")]
    [SerializeField] private GameObject[] Enemies;

    [Tooltip("Радиус области спавна врагов")]
    [Range(5f, 28f)]
    [SerializeField] private float spawnRadius = 25f;
    void Start()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            Vector2 spawnPosition = (Random.insideUnitCircle.normalized * spawnRadius);
            Instantiate(Enemies[i % Enemies.Length], spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
