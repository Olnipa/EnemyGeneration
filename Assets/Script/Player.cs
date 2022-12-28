using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _rootSkill;

    private int _animatorDeathHash;
    private int _animatorCastHash;

    public bool IsAlive { get; private set; }

    private void Start()
    {
        IsAlive = true;
        _animatorDeathHash = Animator.StringToHash(PlayerAnimatorController.State.Death);
        _animatorCastHash = Animator.StringToHash(PlayerAnimatorController.State.Cast);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsAlive) 
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector3.zero);

            if (hit)
            {
                if (hit.collider.TryGetComponent<Skeleton>(out Skeleton skeleton))
                {
                    if (skeleton.IsAlive)
                    {
                        CastRoot(skeleton);
                    }
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Skeleton>(out Skeleton enemy) && IsAlive)
        {
            IsAlive = false;
            _animator.Play(_animatorDeathHash);
            Debug.Log("You are dead. Game Over.");
        }
    }

    private void CastRoot(Skeleton enemy)
    {
        Instantiate(_rootSkill, enemy.transform.position, Quaternion.identity);
        enemy.TakeDamage();
        _animator.Play(_animatorCastHash);
    }
}
