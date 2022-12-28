using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Transform))]

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    private UnityEvent _spawnedEnemy = new UnityEvent();

    public event UnityAction OnSpawnEnemy
    {
        add => _spawnedEnemy.AddListener(value);
        remove => _spawnedEnemy.RemoveListener(value);
    }

    private void Start()
    {
        _spawnedEnemy.AddListener(SpawnNewEnemy);
    }

    private void SpawnNewEnemy()
    {
        Instantiate(_enemy, transform.position, Quaternion.identity);
    }

    public void InvokeEnemySpowner()
    {
        _spawnedEnemy.Invoke();
    }
}


