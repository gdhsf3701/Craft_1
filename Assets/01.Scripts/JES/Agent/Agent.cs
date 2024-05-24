using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    #region Component section
    public AgentMovement MovementCompo { get; protected set; }
    public Animator AnimatorCompo { get; protected set; }
    public Health HealthCompo { get; private set; }
    #endregion

    public bool IsDead { get; protected set; }

    protected float _timeInAir;

    protected virtual void Awake()
    {
        MovementCompo = GetComponent<AgentMovement>();
        MovementCompo.Initialize(this);
        AnimatorCompo = transform.Find("Visual").GetComponent<Animator>();

        HealthCompo = GetComponent<Health>();
        HealthCompo.Initalize(this);
    }

    #region Flip Character
    public bool IsFacingRight()
    {
        return Mathf.Approximately(transform.eulerAngles.y, 0);
    }

    public void HandleSpriteFlip(Vector3 targetPosition)
    {
        if (targetPosition.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if (targetPosition.x > transform.position.x)
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }
    #endregion
}
