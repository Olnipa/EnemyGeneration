using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Transform))]

public class SpawnPoint : MonoBehaviour
{
    public UnityEvent SpawnEnemy;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _transform;

    public event UnityAction OnSpawnEnemy
    {
        add => SpawnEnemy.AddListener(value);
        remove => SpawnEnemy.RemoveListener(value);
    }

    private void Start()
    {
        _transform = GetComponent<Transform>();
        SpawnEnemy.AddListener(SpawnNewEnemy);
    }

    private void SpawnNewEnemy()
    {
        Instantiate(_enemy, new Vector3(_transform.position.x, _transform.position.y, _transform.position.z), Quaternion.identity);
    }
}


