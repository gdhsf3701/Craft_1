using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKeyWait : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChatSystem.Instance.TypCoStart("���ڿ�", "��.. �̷��ǰ�?", 0.2f);
    }

}
