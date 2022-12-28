using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Skeleton _skeleton;

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

    private void OnDisable()
    {
        _spawnedEnemy.RemoveListener(SpawnNewEnemy);
    }

    private void SpawnNewEnemy()
    {
        Instantiate(_skeleton, transform.position, Quaternion.identity);
    }

    public void InvokeSpawnedEnemy()
    {
        _spawnedEnemy.Invoke();
    }
}