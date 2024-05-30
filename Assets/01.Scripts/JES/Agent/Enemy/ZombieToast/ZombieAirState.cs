using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAirState : EnemyState
{
    public ZombieAirState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementCompo.isGround.OnValueChanged += HandleGroundChage;
    }

    private void HandleGroundChage(bool prev, bool next)
    {
        if (next)
        {
            _stateMachine.ChangeState(ZombieEnum.Idle);
        }
    }

    public override void Exit()
    {
        _enemy.MovementCompo.isGround.OnValueChanged -= HandleGroundChage;
        base.Exit();

    }
}
