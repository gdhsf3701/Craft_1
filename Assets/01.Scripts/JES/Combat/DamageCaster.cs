using System.Collections.Generic;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    public LayerMask layerMask;

    [Header("Setting")]
    public int damage;
    public float knockbackPower;
    public float cooltime;
    [SerializeField] private Vector2 boxSize;
    [SerializeField]
    private List<int> DamageList = new List<int>();


    public int comboCount;
    private float comboTime = 0.75f;
    private float currentTime;
    private void Update()
    {
        if (!Attack.Instance.attacking.Value)
        {
            if (currentTime > comboTime)
            {
                comboCount = 0;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }

        if (comboCount >= 3)
        {
            comboCount = 0;
            currentTime = 0;
        }
        else
        {
            damage = DamageList[comboCount];
        }
    }
    public void CastDamage()
    {
        if (!Attack.Instance.attacking.Value)
        {
            comboCount++;
            currentTime = 0;
            Attack.Instance.attacking.Value = true;
            Collider2D colliider = Physics2D.OverlapBox(transform.position, boxSize, layerMask);

            Debug.Log(damage);
            if (colliider)
            {
                if (colliider.TryGetComponent(out Health health))
                {
                    Vector2 direction = colliider.transform.position - transform.position;

                    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, direction.magnitude, layerMask);

                    health.TakeDamage(damage, hit.normal, hit.point, knockbackPower);
                }
            }

        }

    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, boxSize);
        Gizmos.color = Color.white;
    }
#endif
}
