using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ZombieDeadState : EnemyState
{
    private readonly int _deadLayer = LayerMask.NameToLayer("DeadBody");

    private bool _onExplosion = false;
    public ZombieDeadState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.gameObject.layer = _deadLayer;
        _enemy.MovementCompo.StopImmediately();
        _enemy.SetDead(true);
        _onExplosion=false;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_endTriggerCalled && !_onExplosion) {
            _onExplosion = true;
            PlayExpolsion();
        }
    }

    private void PlayExpolsion()
    {
        _enemy.FinalDeadEvent?.Invoke();


        Ipoolable ipoolable = _enemy.GetComponent<Ipoolable>();
        if(ipoolable != null )
        {
            PoolManager.Instance.Push(ipoolable);
        }else
        {
            GameObject.Destroy(_enemy.gameObject);
        }
    }
}
