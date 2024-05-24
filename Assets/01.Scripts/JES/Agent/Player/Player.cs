using UnityEngine;
using UnityEngine.Events;

public class Player : Agent
{
    public UnityEvent JumpEvent;
    [field: SerializeField] public InputReader PlayerInput { get; private set; }

    private bool _canDoubleJump;

    protected override void Awake()
    {
        base.Awake();

        PlayerInput.OnJumpKeyEvent += HandleJumpKeyEvent;
    }


    private void OnDestroy()
    {
        PlayerInput.OnJumpKeyEvent -= HandleJumpKeyEvent;
    }

    private void HandleJumpKeyEvent()
    {
        if (MovementCompo.isGround.Value)
        {
            _canDoubleJump = true;
            JumpProcess();
        }
        else if (_canDoubleJump)
        {
            _canDoubleJump = false;
            JumpProcess();
        }
    }
    private void Update()
    {
        MovementCompo.SetMoveMent(PlayerInput.Movement.x);
        SpriteFlip(PlayerInput.Movement);
    }

    private void SpriteFlip(Vector2 movement)
    {
        if (movement.x < 0)
        {
            int x = -1;
            transform.localScale = new Vector3(x, 1, 1);
        }
        else if (movement.x > 0)
        {
            int x = 1;
            transform.localScale = new Vector3(x, 1, 1);
        }
    }

    private void JumpProcess()
    {
        JumpEvent?.Invoke();
        MovementCompo.Jump();
    }


}
