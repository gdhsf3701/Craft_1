using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Agent
{
    
    public PlayerStateMachine stateMachine;

    public List<PlayerDamageSO> damageDataList;
    public UnityEvent JumpEvent;
    [field: SerializeField] public InputReader PlayerInput { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine(); 
        
        stateMachine.AddState(PlayerEnum.Idle,new PlayerIdleState(this,stateMachine,"Idle"));
        stateMachine.AddState(PlayerEnum.Run,new PlayerRunState(this,stateMachine,"Run"));
        stateMachine.AddState(PlayerEnum.Jump,new PlayerJumpState(this,stateMachine,"Jump"));
        stateMachine.AddState(PlayerEnum.Fall,new PlayerFallState(this,stateMachine,"Fall"));
        stateMachine.AddState(PlayerEnum.Attack1,new PlayerAttack1State(this,stateMachine,"Attack1"));
        stateMachine.AddState(PlayerEnum.Attack2,new PlayerAttack2State(this,stateMachine,"Attack2"));
        stateMachine.AddState(PlayerEnum.Attack3,new PlayerAttack3State(this,stateMachine,"Attack3"));
        
        stateMachine.Initialize(PlayerEnum.Idle, this);

        PlayerInput.OnJumpKeyEvent += HandleJumpKeyEvent;
    }
    
   

    public void Attack()
    {
        //공격 함수
        //나중에 so로 계속 갈아끼우면서 할예정
    }

    private void OnDestroy()
    {
        PlayerInput.OnJumpKeyEvent -= HandleJumpKeyEvent;
    }

    private void HandleJumpKeyEvent()
    {
        if (MovementCompo.isGround.Value)
            JumpProcess();
    }
    private void Update()
    {
        
        
        float x = PlayerInput.Movement.x;
        SpriteFlip(x);
        MovementCompo.SetMoveMent(x);
    }

    private void SpriteFlip(float x)
    {
        bool isRight = IsFacingRight();
        if (x < 0 && isRight)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
        }
        else if (x> 0 && !isRight)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    
    private void JumpProcess()
    {
        JumpEvent?.Invoke();
        MovementCompo.Jump();
    }

    public override void SetDeadState()
    {
        stateMachine.ChangeState(PlayerEnum.Dead);
    }
    
    public void AnimationEndTrigger()
    {
        stateMachine.CurrentState.AnimationEndTrigger();
    }
}
