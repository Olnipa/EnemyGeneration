using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnTrigger : MonoBehaviour
{
    private SpawnPoint[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(EnemySpawnJob());
    }

    private IEnumerator EnemySpawnJob()
    {
        var waitTwoSeconds = new WaitForSeconds(2f);

        while (true)
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                spawnPoint.SpawnEnemy.Invoke();
                yield return waitTwoSeconds;
            }
        }
    }
}
