using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerDefaultState : PlayerState
{
    
    
    protected PlayerDefaultState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.isGround.OnValueChanged += HandleGroundChange;
        HandleGroundChange(false,_player.MovementCompo.isGround.Value);
    }

    private void HandleGroundChange(bool prev, bool next)
    {
        if(next == false)
        {
            _stateMachine.ChangeState(PlayerEnum.Jump);
        }
    }

    public override void Exit()
    {
        _player.MovementCompo.isGround.OnValueChanged -= HandleGroundChange;
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
