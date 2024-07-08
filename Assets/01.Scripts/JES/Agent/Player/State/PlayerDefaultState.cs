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
        _player.PlayerInput.OnPunchKeyEvent += HandleAttackEvent;
    }

    private void HandleAttackEvent()
    {
        if (_player.lastAttackTime + _player.attackCoolDown < Time.time)
        {
            _stateMachine.ChangeState((PlayerEnum)_player.comboCount);
        }
    }
    

    private void HandleGroundChange(bool prev, bool next)
    {
        if(next == false)
        {
            _stateMachine.ChangeState(PlayerEnum.Jump);
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        if(_player.comboCount<=0) return;
        
        if (_player.lastAttackTime + 0.4 < Time.time)
        {
            _player.comboCount = 0;
            _player.attackCoolDown = _player.damageData.attackCooldown;
            _player.lastAttackTime = Time.time;
        }
    }

    public override void Exit()
    {
        _player.PlayerInput.OnPunchKeyEvent -= HandleAttackEvent;
        _player.MovementCompo.isGround.OnValueChanged -= HandleGroundChange;
        base.Exit();
    }
    
}
