using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunKnifeChaceState : EnemyState
{
    public GunKnifeChaceState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Vector2 dir = (_enemy.targerTrm.position - _enemy.transform.position);
        float dis = dir.magnitude;
        if (dis > _enemy.detectRadius + 2)
        {
            _stateMachine.ChangeState(EnemyEnum.Idle);
            return;
        }
        _enemy.MovementCompo.SetMoveMent(Mathf.Sign(dir.x));
        if (_enemy.attackRadius > dis && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
        {
            _stateMachine.ChangeState(EnemyEnum.Fire);
        }
    }
}
