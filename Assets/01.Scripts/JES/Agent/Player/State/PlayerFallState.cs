using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.isGround.OnValueChanged += HandleGroundChange;
    }

    public override void Exit()
    {
        _player.MovementCompo.isGround.OnValueChanged -= HandleGroundChange;
        base.Exit();
    }

    private void HandleGroundChange(bool prev, bool next)
    {
        if(next)
        {
            _stateMachine.ChangeState(PlayerEnum.Idle);
        }
    }
}
