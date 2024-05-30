using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZombieGroundState : EnemyState
{
    public ZombieGroundState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementCompo.isGround.OnValueChanged += HandleGroundChange;
        HandleGroundChange(false, _enemy.MovementCompo.isGround.Value);
    }

    private void HandleGroundChange(bool prev, bool next)
    {
        if(!next) {
            _stateMachine.ChangeState(ZombieEnum.Air);
        }
    }

    public override void Exit()
    {
        _enemy.MovementCompo.isGround.OnValueChanged -= HandleGroundChange;
        base.Exit();
    }
}
