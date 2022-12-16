using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFabric : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Vector3 _spawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.5f);
            Instantiate(_enemyPrefab, _spawnPoint, Quaternion.identity);
        }
    }
}
