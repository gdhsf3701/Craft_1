using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack3State : PlayerState
{
    public override void UpdateState()
    {
        base.UpdateState();
        _player.MovementCompo.StopImmediately(false);
        if(_endTriggerCalled)
        {
            _stateMachine.ChangeState(PlayerEnum.Idle);
        }
    }

    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.StopImmediately(false);
    }

    public override void Exit()
    {
        _player.lastAttackTime = Time.time-1;
        base.Exit();
    }

    public PlayerAttack3State(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
}
