using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private AgentMovement _movement;

    private Animator _animator;

    private readonly int _idleHash = Animator.StringToHash("Idle");
    private readonly int _jumpHash = Animator.StringToHash("Jump");
    private readonly int _runHash = Animator.StringToHash("Run");
    private readonly int _attackHash = Animator.StringToHash("Attack");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement.isGround.OnValueChanged += HandleGroundChanged;
        Attack.Instance.attacking.OnValueChanged += HandleAttackChanged;
    }

    private void HandleGroundChanged(bool prev, bool next)
    {
        _animator.SetBool(_jumpHash, next);
        if (!next){
            _animator.SetBool(_idleHash, false);
            _animator.SetBool(_runHash, false);
        }
    }
    private void HandleAttackChanged(bool prev, bool next)
    {
        _animator.SetBool(_attackHash, next);
        if (next)
        {
            _animator.SetBool(_idleHash, false);
            _animator.SetBool(_runHash, false);
        }
    }
    private void FixedUpdate()
    {
        float absVelocity = Mathf.Abs(_movement.rbCompo.velocity.x);
        ChangeWalk(absVelocity);
    }

    private void ChangeWalk(float absVelocity)
    {
        if (absVelocity > 0)
        {
            _animator.SetBool(_idleHash, false);
            _animator.SetBool(_runHash, true);
        }
        else
        {
            _animator.SetBool(_idleHash, true);
            _animator.SetBool(_runHash, false);
        }
    }
}
