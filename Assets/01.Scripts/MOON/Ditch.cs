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
    AgentMovement agentMovement;
    float saveSpeed = 0;
    float saveJump = 0;

    bool CoolTime=false;

    private void Start()
    {
        Player = GameObject.Find("Player");
        agentMovement = Player.GetComponent<AgentMovement>();
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
        if (agentMovement.moveSpeed == 0)
        {
            agentMovement.moveSpeed = saveSpeed;
            agentMovement.jumpPower = saveJump;
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
            saveSpeed = agentMovement.moveSpeed;
            saveJump = agentMovement.jumpPower;
            agentMovement.moveSpeed = 0;
            agentMovement.jumpPower = 0;
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
