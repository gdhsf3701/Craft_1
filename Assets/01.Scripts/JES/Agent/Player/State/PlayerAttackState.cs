using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    
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
        _player.HealthCompo.OnHitEvent.AddListener(HandleHitEvent);
        SkillCoolUI.Instance.ComboImageSetUp();
    }

    private void HandleHitEvent()
    {
        _stateMachine.ChangeState(PlayerEnum.Hit);
    }

    public override void Exit()
    {
        SkillCoolUI.Instance.ComboCooldown();
        _player.HealthCompo.OnHitEvent.RemoveListener(HandleHitEvent);
        _player.lastAttackTime = Time.time;
        base.Exit();
    }
}
