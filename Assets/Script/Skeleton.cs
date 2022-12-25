using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

    private bool _isAlive;
    private bool _enemySpotted;
    private bool _isMovable;

    private void Start()
    {
        _isMovable = true;
        _speed = 0.01f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _enemySpotted = true;

            if (_isMovable && _isAlive)
            {
                _animator.SetFloat("Speed", _speed);
                _animator.Play("SkeletonMove");
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, _speed);
            }
        }
    }

    private void ToMarkAlive()
    {
        _isAlive = true;
        _animator.SetBool("IsAlive", _isAlive);
    }
}
