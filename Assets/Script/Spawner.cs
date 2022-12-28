using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _player;

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
                Debug.Log("_player.IsAlive: " + _player.IsAlive);

                if (_player.IsAlive == false)
                {
                    Debug.Log("_player.IsAlive == false");
                    _isSpawning = false;
                }

                spawnPoint.InvokeSpawnedEnemy();
                yield return waitTwoSeconds;
            }
        }
    }
}