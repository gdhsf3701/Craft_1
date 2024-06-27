using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private AgentMovement _movement;
    [SerializeField] private Punch _punchCompo;
    [SerializeField] private Kick _KickCompo;
    private Animator _animator;

    private readonly int _idleHash = Animator.StringToHash("Idle");
    private readonly int _jumpHash = Animator.StringToHash("Jump");
    private readonly int _runHash = Animator.StringToHash("Run");
    private readonly int _attackHash = Animator.StringToHash("Attack");
    private readonly int _punchHash = Animator.StringToHash("PunchCombo");
    private readonly int _KickHash = Animator.StringToHash("KickCombo");

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _movement.isGround.OnValueChanged += HandleGroundChanged;
        Attack.Instance.attacking.OnValueChanged += HandleAttackChanged;

        _punchCompo.damageCompo.comboCount.OnValueChanged += PunchComboAni;
        _KickCompo.damageCompo.comboCount.OnValueChanged += KickComboAni;
    }
    private void HandleGroundChanged(bool prev, bool next)
    {
        _animator.SetBool(_jumpHash, next);
        if (!next)
            OffIdleAndRun();
    }
    private void HandleAttackChanged(bool prev, bool next)
    {
        _animator.SetBool(_attackHash, next);
        if (next)
            OffIdleAndRun();
    }
    private void OffIdleAndRun()
    {
        _animator.SetBool(_idleHash, false);
        _animator.SetBool(_runHash, false);
    }
    public void PunchComboAni(int prev, int next)
    {
        _animator.SetInteger(_punchHash, next);
    }
    public void KickComboAni(int prev, int next)
    {
        _animator.SetInteger(_KickHash, next);
    }
    private void FixedUpdate()
    {
        float absVelocity = Mathf.Abs(_movement.rbCompo.velocity.x);
        ChangeWalk(absVelocity);
    }
    private void ChangeWalk(float absVelocity)
    {
        _animator.SetBool(_idleHash, !(absVelocity > 0));
        _animator.SetBool(_runHash, absVelocity > 0);
    }
    public void AnimEndTrriger()
    {
        Attack.Instance.attacking.Value = false;
    }
}
