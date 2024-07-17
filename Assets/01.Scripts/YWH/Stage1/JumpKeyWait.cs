using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKeyWait : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Musul());
    }

    IEnumerator Musul()
    {
        ChatSystem.Instance.TypCoStart("���´�", "���� �ͼ����� �� ���� ���̴�..", 0.2f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        ChatSystem.Instance.TypCoStart("���´�", "������ �����̴�!", 0.2f);
    }
}
