using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]

public class Skeleton : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Player _enemy;

    private float _maxSpeed;
    private float _minSpeed;
    private CapsuleCollider2D _capsuleCollider2D;
    private bool _isCollisionWithEnemy;

    private int _animatorSpeedHash;
    private int _animatorIsAliveHash;
    private int _animatorDeathHash;
    private int _animatorMoveHash;
    private int _animatorAttackHash;

    public bool IsAlive { get; private set; }

    private void Start()
    {
        _isCollisionWithEnemy = false;
        _maxSpeed = 0.01f;
        _minSpeed = 0;
        _animatorSpeedHash = Animator.StringToHash(SkeletonAnimatorController.Parametr.Speed);
        _animatorIsAliveHash = Animator.StringToHash(SkeletonAnimatorController.Parametr.IsAlive);
        _animatorDeathHash = Animator.StringToHash(SkeletonAnimatorController.State.Death);
        _animatorMoveHash = Animator.StringToHash(SkeletonAnimatorController.State.Move);
        _animatorAttackHash = Animator.StringToHash(SkeletonAnimatorController.State.Attack);
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _capsuleCollider2D.enabled = false;
    }

    private void FixedUpdate()
    {
        if (_isCollisionWithEnemy == false)
        {
            _enemy = FindObjectOfType<Player>();

            if (_enemy.IsAlive && IsAlive)
            {
                MoveToEnemy(_enemy);
            }
            else
            {
                StopMoving();
            }
        }
        else
        {
            StopMoving();
        }
    }

    private void MoveToEnemy(Player player)
    {
        _animator.SetFloat(_animatorSpeedHash, _maxSpeed);
        _animator.Play(_animatorMoveHash);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, _maxSpeed);
    }

    private void StopMoving()
    {
        _animator.SetFloat(_animatorSpeedHash, _minSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<Player>(out Player player))
        {
            _isCollisionWithEnemy = true;

            if (player.IsAlive)
                _animator.Play(_animatorAttackHash);
            else
                StopMoving();
        }
        else
        {
            StopMoving();
        }
    }

    private void ToMarkAlive()
    {
        IsAlive = true;
        _animator.SetBool(_animatorIsAliveHash, IsAlive);
        _capsuleCollider2D.enabled = true;
    }

    public void TakeDamage()
    {
        _animator.Play(_animatorDeathHash);
        IsAlive = false;
        _animator.SetBool(_animatorIsAliveHash, IsAlive);
        _capsuleCollider2D.enabled = false;
    }
}