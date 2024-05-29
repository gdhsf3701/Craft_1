using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public Player _Player;
    public DamageCaster damageCompo;
    private void Awake()
    {
        _Player = GetComponentInParent<Player>();   
        damageCompo = GetComponent<DamageCaster>();
        _Player.PlayerInput.OnKickKeyEvent += damageCompo.CastDamage;
    }
    private void OnDisable()
    {
        _Player.PlayerInput.OnKickKeyEvent -= damageCompo.CastDamage;
    }
}