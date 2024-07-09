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
        
        _player.HealthCompo.OnHitEvent.AddListener(HandleHitEvent);
        _player.PlayerInput.OnJumpKeyEvent += HandleJumpKeyEvent;
    }
    
    private void HandleHitEvent()
    {
        _stateMachine.ChangeState(PlayerEnum.Hit);
    }
    private void HandleJumpKeyEvent()
    {
        if (_player.MovementCompo.isGround.Value)
            _player.JumpProcess();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        float x = _player.PlayerInput.Movement.x;
        _player.SpriteFlip(x);
        _player.MovementCompo.SetMoveMent(x);
        
        if(_player.comboCount<=0) return;
        
        if (_player.lastAttackTime + 0.7 < Time.time)
        {
            _player.comboCount = 0;
            _player.attackCoolDown = _player.damageData.attackCooldown;
            _player.lastAttackTime = Time.time;
            SkillCoolUI.Instance.NormalAttackCoolStart(_player.attackCoolDown);
            SkillCoolUI.Instance.ComboImageSetUp();
        }
    }

    public override void Exit()
    {
        _player.PlayerInput.OnJumpKeyEvent -= HandleJumpKeyEvent;
        _player.HealthCompo.OnHitEvent.RemoveListener(HandleHitEvent);
        base.Exit();
    }
    
}
