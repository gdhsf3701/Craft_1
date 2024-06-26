using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CSI_Item : MonoBehaviour
{
    private GameObject Player_item,Player;
    private bool can_get_item,can_change;
    private float speed = 1000;
    public bool itahamsu;
    
    private Vector3 startPos, endPos;
    //땅에 닫기까지 걸리는 시간
    private float timer;
    private float timeToFloor;
    
    
    private static Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

    private IEnumerator BulletMove()
    {
        timer = 0;
        while (transform.position.y>=startPos.y-30)
        {
            timer += Time.deltaTime;
            Vector3 tempPos = Parabola(startPos, endPos, 5, timer);
            transform.position = tempPos;
            yield return new WaitForEndOfFrame();
        }
    }


    
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////hgf
    /// </summary>

    public bool Throw { get; set; }

    private void Awake()
    {
        Player_item = GameObject.Find("Item_");//플래이어 자식으로 있는 아이템
        Throw = false;
        can_change = false;
        Player = GameObject.Find("Player_CSI");//플래이어 이름을 넣어야합니다......[SerializeField]--사용 금지--(자동화 불가.)

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)&&can_get_item&& !Throw)
        {
            if (can_change)
            {
                GameObject fire_item;
                fire_item = Player_item.transform.GetChild(0).gameObject;
                fire_item.transform.parent = null;
                transform.position = Player_item.transform.position;
                transform.parent = Player_item.transform;
            }
            else if (Player_item.transform.childCount == 0)
            {
                transform.position = Player_item.transform.position;
                transform.parent = Player_item.transform;
            }
            else
            {
                GameObject fire_item;
                fire_item = Player_item.transform.GetChild(0).gameObject;
                fire_item.transform.parent = null;
                fire_item.GetComponent<CSI_Item>().Throw = true;
                if (!itahamsu)
                {
                    if (Player.transform.position.x>0)
                    {
                        fire_item.GetComponent<Rigidbody2D>().velocity += Vector2.right *Time.fixedDeltaTime * speed;

                    }
                    else
                    {
                        fire_item.GetComponent<Rigidbody2D>().velocity += Vector2.left *Time.fixedDeltaTime * speed;

                    }
                }
                else
                {
                    startPos = fire_item.transform.position;
                    if (Player.transform.position.x>0)
                        endPos = startPos + new Vector3(10, 0, 0);
                    else
                    {
                        endPos = startPos + new Vector3(-10, 0, 0);

                    }
                    StartCoroutine("BulletMove");
                }

            }
        }
    }


    private void Throwandthouch()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!can_get_item && Throw &&!other.transform.CompareTag("Player"))
        {
            if (other.transform.CompareTag("Ground"))
            {
                Throwandthouch();
            }
        }
        if (other.transform.CompareTag("Player"))
        {
            if (Player_item.transform.childCount != 0)//손에 가지고 있다
            {
                can_change = true;
            }
            can_get_item = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (Player_item.transform.childCount != 0)//손에 가지고 있다
            {
                can_change = false;
            }
            can_get_item = false;
        }
    }
}
