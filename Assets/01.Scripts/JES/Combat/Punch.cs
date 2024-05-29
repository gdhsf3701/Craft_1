using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public Player _Player;
    public DamageCaster damageCompo;
    private void Awake()
    {
        _Player = GetComponentInParent<Player>();
        damageCompo =GetComponent<DamageCaster>();
        _Player.PlayerInput.OnPunchKeyEvent += damageCompo.CastDamage;
    }
    private void OnDisable()
    {
        _Player.PlayerInput.OnPunchKeyEvent -= damageCompo.CastDamage;
    }
}