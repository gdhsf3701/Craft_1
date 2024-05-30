using UnityEngine;

public enum ZombieEnum
{
    Air,
    Idle,
    Chase,
    Attack,
    Dead
}

public class ZombieEnemy : Enemy, Ipoolable
{
    public EnemyStateMachine stateMachine;
    [SerializeField] private string _poolName = "ZombieEnemy";
    public string PoolName => _poolName;

    public GameObject ObjectPrefab => gameObject;

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine();

        stateMachine.AddState(ZombieEnum.Idle, new ZombieIdleState(this, stateMachine, "Idle"));
        stateMachine.AddState(ZombieEnum.Chase, new ZombieChaseState(this, stateMachine, "Chase"));
        stateMachine.AddState(ZombieEnum.Air, new ZombieAirState(this, stateMachine, "Air"));
        stateMachine.AddState(ZombieEnum.Attack, new ZombieAttackState(this, stateMachine, "Attack"));
        stateMachine.AddState(ZombieEnum.Dead, new ZombieDeadState(this, stateMachine, "Dead"));

        stateMachine.Initalize(ZombieEnum.Idle, this);
    }
    private void Update()
    {
        stateMachine.CurrentState.UpdateState();

        if (targerTrm != null && IsDead == false)
        {
            HandleSpriteFlip(targerTrm.position);
        }
    }
    public override void AnimationEndTrigger()
    {
        stateMachine.CurrentState.AnimationEndTrigger();
    }

    public override void SetDeadState()
    {
        stateMachine.ChangeState(ZombieEnum.Dead);
    }

    public void ResetItem()
    {
        CanStateChangeable = true;
        IsDead = false;
        targerTrm = null;
        HealthCompo.ResetHealth();
        stateMachine.ChangeState(ZombieEnum.Idle);
        gameObject.layer = _enemyLayer;
    }
}
