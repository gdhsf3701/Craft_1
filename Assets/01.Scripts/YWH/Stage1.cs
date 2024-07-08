using System.Collections;
using UnityEngine;

public class Stage1 : MonoBehaviour
{



    void Start()
    {
        FadeManager.instance.FadeOut(1);
        ChatSystem.Instance.TypCoStart("���ڿ�", "��.. �̷��ǰ�?", 0.2f);

        StartCoroutine(MasterSay());
    }

    IEnumerator MasterSay()
    {
        yield return new WaitForSeconds(2);
        ChatSystem.Instance.StopTyp();

        yield return new WaitForSeconds(3);

        ChatSystem.Instance.TypCoStart("���´�", "�ῡ�� ������?", 0.2f);
        yield return new WaitUntil(() =>ChatSystem.Instance.endText==true);
        yield return new WaitForSeconds(0.5f);
        ChatSystem.Instance.TypCoStart("���´�", "�׷� �������� �Ʒ��� �������ڲٳ�.", 0.2f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        yield return new WaitForSeconds(0.5f);
        ChatSystem.Instance.StopTyp();
    }
}
