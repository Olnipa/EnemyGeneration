using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _enemy;

    private SpawnPoint[] _spawnPoints;
    private bool _isSpawning;

    private void Start()
    {
        _isSpawning = true;
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(EnemySpawnJob());
    }

    private IEnumerator EnemySpawnJob()
    {
        var waitTwoSeconds = new WaitForSeconds(2f);

        while (_isSpawning)
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                if (_enemy.IsAlive == false)
                {
                    _isSpawning = false;
                }

                spawnPoint.InvokeEnemySpowner();
                yield return waitTwoSeconds;
            }
        }
    }
}