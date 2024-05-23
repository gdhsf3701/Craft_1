using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;


[CreateAssetMenu(menuName ="SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public Vector2 Movement { get; private set; }
    
    private Controls _controls;

    public event Action OnPunchKeyEvent;
    public event Action OnKickKeyEvent;
    public event Action OnCounterKeyEvent;
    public event Action OnJumpKeyEvent;
    public event Action OnSkillEvent;

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
        }
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
    }

    public void OnCounter(InputAction.CallbackContext context)
    {
        OnCounterKeyEvent?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        OnJumpKeyEvent?.Invoke();
    }

    public void OnKick(InputAction.CallbackContext context)
    {
        OnKickKeyEvent?.Invoke();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        OnPunchKeyEvent?.Invoke();
    }

    public void OnSkill(InputAction.CallbackContext context)
    {
        OnSkillEvent?.Invoke();
    }
}