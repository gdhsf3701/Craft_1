using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyEnum
{
    Idle,
    Chase,
    Fire,
    KnifeChase,
    Attack,
    Dead
}
public class GunKnifeEnemy : Enemy, Ipoolable
{
    public EnemyStateMachine stateMachine;
    [SerializeField] private string _poolName = "GunKnifeEnemy";

    public string PoolName => _poolName;

    public GameObject ObjectPrefab => gameObject;

    
    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine();

        stateMachine.AddState(EnemyEnum.Idle,new GunIdleState(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyEnum.Chase,new GunChaseState(this, stateMachine, "Chase"));
        stateMachine.AddState(EnemyEnum.Fire,new GunFireState(this, stateMachine, "Fire"));
        stateMachine.AddState(EnemyEnum.Dead,new GunDeadState(this, stateMachine, "Dead"));
        stateMachine.AddState(EnemyEnum.KnifeChase,new GunKnifeChaseState(this, stateMachine, "KnifeChase"));
        stateMachine.AddState(EnemyEnum.Attack,new GunAttackState(this, stateMachine, "Attack"));

        stateMachine.Initalize(EnemyEnum.Idle,this);

    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState(); // ���� ������ ������Ʈ �켱 ����

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
        stateMachine.ChangeState(EnemyEnum.Dead);
    }

    public void ResetItem() //���� �� �ٽ� ��ȯ�ɶ�
    {
        CanStateChangeable = true; // ���¸� ���� �� �� �ִ���, �ƴ���
        IsDead = false; // �׾����� �ƴ���
        targerTrm = null; // Ÿ�� Ʈ������ �ʱ�ȭ
        HealthCompo.ResetHealth(); // ü�� �ʱ�ȭ
        stateMachine.ChangeState(EnemyEnum.Idle); // idle ���·� �ٲٱ�
        gameObject.layer = _enemyLayer; // ���̾� ���ʹ� ���̾�� �ٲٱ�
    }
}
