using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWireState : PlayerState
{
    public PlayerWireState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput._controls.Disable();
        _player.MovementCompo.StopImmediately(true);
    }

    public override void Exit()
    {
        _player.PlayerInput._controls.Enable();
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!Zipline.isMove)
        {
            _stateMachine.ChangeState(PlayerEnum.Idle);
        }
    }
}
