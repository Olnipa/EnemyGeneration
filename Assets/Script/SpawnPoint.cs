using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Skeleton _skeleton;

    public void SpawnNewEnemy()
    {
        Instantiate(_skeleton, transform.position, Quaternion.identity);
    }
}