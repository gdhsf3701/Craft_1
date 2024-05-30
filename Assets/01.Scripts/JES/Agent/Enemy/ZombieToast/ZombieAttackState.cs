using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : EnemyState
{
    private float _attackJumpPower = 3f;
    public ZombieAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementCompo.StopImmediately(false);

        Vector2 dir = _enemy.targerTrm.position-_enemy.transform.position;
        dir.y = _attackJumpPower;
        dir.x *= 0.5f;
        _enemy.MovementCompo.JumpTo(dir);
    }

    public override void Exit()
    {
        _enemy.lastAttackTime = Time.time;
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
            _stateMachine.ChangeState(ZombieEnum.Chase);
    }
}
