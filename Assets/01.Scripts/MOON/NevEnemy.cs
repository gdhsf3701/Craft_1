using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NevEnemy : MonoBehaviour
{
    [SerializeField]GameObject target;
    Camera cam;
    Vector3 tar;
    private Vector2 leftdownLimit;
    private Vector2 rightupLimit;
    float speed;
    private void Awake()
    {
        cam = Camera.main;
        leftdownLimit = cam.ViewportToWorldPoint(new Vector2(0, 1));
        rightupLimit = cam.ViewportToWorldPoint(new Vector2(1, 0));
    }
    private void Update()
    {
        transform.position = (target.transform.position - transform.position).normalized * speed;
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftdownLimit.x, rightupLimit.x), Mathf.Clamp(transform.position.y, rightupLimit.y, leftdownLimit.y), 0);
    }
}
