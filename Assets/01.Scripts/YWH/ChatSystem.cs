using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ChatSystem : MonoSingleton<ChatSystem>
{
    [SerializeField] private TextMeshProUGUI chatName;
    [SerializeField] private TextMeshProUGUI desc;



   public void TypCoStart(string name, string text, float rate)
    {
        StartCoroutine(Typing(text, rate));
        chatName.text = name;
        chatName.DOFade(1, 1);
        desc.DOFade(1, 1);
    }

    private IEnumerator Typing(string text, float rate)
    {
        for (int i = 0; i <= text.Length; i++)
        {
            desc.text = text.Substring(0, i);
            
            yield return new WaitForSecondsRealtime(rate);
        }
        yield return new WaitForSeconds(1.5f);
        chatName.DOFade(0, 1);
        desc.DOFade(0, 1);
    }
}
