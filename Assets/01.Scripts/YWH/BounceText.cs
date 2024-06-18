using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BounceText : MonoBehaviour
{

    private RectTransform text;

    private void Awake()
    {
        text = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        text.DOMove(new Vector3(text.position.x, text.position.y + 0.45f, text.position.z),1f).SetLoops(-1, LoopType.Yoyo);
    }

    
}
