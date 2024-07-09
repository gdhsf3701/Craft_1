using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Stage1 : MonoBehaviour
{

    [SerializeField] private CanvasGroup keyUI;

    void Start()
    {
        FadeManager.instance.FadeOut(1);
        ChatSystem.Instance.TypCoStart("금자월", "또.. 이런건가?", 0.2f);

        StartCoroutine(MasterSay());
    }

    IEnumerator MasterSay()
    {
        yield return new WaitForSeconds(2);
        ChatSystem.Instance.StopTyp();

        yield return new WaitForSeconds(3);

        ChatSystem.Instance.TypCoStart("스승님", "잠에서 깼느냐?", 0.2f);
        yield return new WaitUntil(() =>ChatSystem.Instance.endText==true);
        yield return new WaitForSeconds(0.5f);
        ChatSystem.Instance.TypCoStart("스승님", "그럼 이제부터 훈련을 시작하자꾸나.", 0.2f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        yield return new WaitForSeconds(0.5f);
        ChatSystem.Instance.StopTyp();
        yield return new WaitForSeconds(3);
        keyUI.gameObject.SetActive(true);
        keyUI.DOFade(1, 1);
       
    }
}
