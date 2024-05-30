using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ZombieChaseState : ZombieGroundState
{
    public ZombieChaseState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {

    }
    public override void UpdateState()
    {
        base.UpdateState();
        Vector2 dir = (_enemy.targerTrm.position - _enemy.transform.position);
        float dis = dir.magnitude;
        if (dis> _enemy.detectRadius + 3)
        {
            _stateMachine.ChangeState(ZombieEnum.Idle);
            return;
        }
        _enemy.MovementCompo.SetMoveMent(Mathf.Sign(dir.x));
        if(_enemy.attackRadius>dis&&_enemy.lastAttackTime+_enemy.attackCooldown<Time.time)
        {
            _stateMachine.ChangeState(ZombieEnum.Attack);

        }
    }
}
