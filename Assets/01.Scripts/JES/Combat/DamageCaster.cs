using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DamageCaster : MonoBehaviour
{
    public ContactFilter2D filter;
    public float damageRadius;
    public int detectcount = 1;
    public bool atcSuc;

    [Header("Setting")]
    public int damage;
    public float knockbackPower;
    public float cooltime;

    private Collider2D[] _colliders;
    private int comboCount;
    private float comboTime = 1f;
    private float currentTime;
    private float lastAtkTime=0f;
    private Player _Player;
    private void Awake()
    {
        _colliders = new Collider2D[detectcount];
        _Player = GetComponentInParent<Player>();
        _Player.PlayerInput.OnPunchKeyEvent += CastDamage;
    }
    private void Update()
    {
        if (currentTime > comboTime)
        {
            comboCount = 0;
        }
        else
        {
            currentTime += Time.deltaTime;
        }
        if (comboCount == 0)
        {
            damage = 10;
        }
        else if (comboCount == 1)
        {
            damage = 20;
        }
        else if (comboCount == 2)
        {
            damage = 30;
        }
        else if(comboCount >=3)
        {
            comboCount = 0;
            currentTime = 0;
        }
    }
    public void CastDamage()
    {
        if (Time.time > lastAtkTime)
        {
            int cnt = Physics2D.OverlapCircle(transform.position, damageRadius, filter, _colliders);
            if (cnt > 0)
            {
                comboCount++;
                atcSuc = true;
                currentTime = 0;
            }
            for (int i = 0; i < cnt; i++)
            {
                if (_colliders[i].TryGetComponent(out Health health))
                {
                    Debug.Log(damage);
                    Vector2 direction = _colliders[i].transform.position - transform.position;

                    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, direction.magnitude, filter.layerMask);

                    health.TakeDamage(damage, hit.normal, hit.point, knockbackPower);
                }

            }
            lastAtkTime = Time.time + cooltime;
        }
        
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
        Gizmos.color = Color.white;
    }
#endif
}
