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
        ChatSystem.Instance.TypCoStart("스승님", "이제 익숙해진 것 같아 보이니..", 0.2f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        ChatSystem.Instance.TypCoStart("스승님", "다음은 무술이다!", 0.2f);
    }
}
