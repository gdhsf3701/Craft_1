using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ditch : MonoBehaviour
{
    int ditchOut = 0;
    bool isIn = false;
    float gameOverTime = 0;
    public bool GameOver { get; private set; }
    GameObject Player;
    Rigidbody2D rd;

    bool CoolTime=false;

    private void Start()
    {
        Player = GameObject.Find("Player");
        rd = Player.GetComponent<Rigidbody2D>();
        GameOver = false;
    }

    private void Update()
    {
        if (isIn)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                --ditchOut;
                if (ditchOut <= 0)
                {
                    ditchOut = 0;
                    SetRigidbodyToDynamic();
                    isIn = false;
                    StartCoroutine(Cool());
                }
            }
        }
    }

    private void SetRigidbodyToDynamic()
    {
        if (rd.bodyType != RigidbodyType2D.Dynamic)
        {
            rd.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    IEnumerator InDitch()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (ditchOut <= 0)
            {
                break;
            }
            gameOverTime -= 0.1f;
            if (gameOverTime <= 0)
            {
                GameOver = true;
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player&&!CoolTime)
        {
            isIn = true;
            ditchOut = 20;
            gameOverTime = 5;
            rd.bodyType = RigidbodyType2D.Static;
            StartCoroutine(InDitch());
        }
    }
    IEnumerator Cool()
    {
        CoolTime = true;
        yield return new WaitForSeconds(0.5f);
        CoolTime = false;
    }
}
