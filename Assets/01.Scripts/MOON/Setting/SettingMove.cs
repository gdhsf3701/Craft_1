using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMove : MonoBehaviour
{
    bool noOpen = true;
    bool isMove = false;

    Vector3 closePosition = new Vector3(0, 0, 0);
    Vector3 openPosition = new Vector3(0, -1040, 0);

    float closeBorderLeftX = -110;
    float closeBorderRightX = 114;
    
    float openBorderLeftX = -820;
    float openBorderRightX = 829;

    float settingSpeed = 1500f;

    float Distance = 10f;

    private GameObject SettingPanel;

    private RectTransform SettingBorderLeft;
    private RectTransform SettingBorderRight;

    private RectTransform SettingBack;

    
    private void Awake()
    {

        SettingBorderLeft = transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
        SettingBorderRight = transform.GetChild(2).GetChild(1).GetComponent<RectTransform>();

        SettingBack = transform.GetChild(0).GetComponent<RectTransform>(); ;
        SettingBack.localScale = new Vector3(1,8,0);

        SettingPanel = transform.GetChild(1).gameObject;
        SettingPanel.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnOffSetting();
        }
    }

    public void OnOffSetting()
    {
        if (noOpen && !isMove)
        {
            SettingOpen();
        }
        else if (!noOpen && !isMove)
        {
            SettingClose();
        }
    }
    private void Start()
    {
        
    }
    private void SettingOpen()
    {

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveY(-970, 1.5f)).SetEase(Ease.OutSine);

        seq.Append(transform.DOLocalMoveY(-950, 0.15f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-990, 0.175f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-950, 0.2f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-990, 0.225f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-950, 0.25f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-990, 0.275f)).SetEase(Ease.OutExpo);

        seq.Join(SettingBorderLeft.DOAnchorPosX(openBorderLeftX, 0.75f));
        seq.Join(SettingBorderRight.DOAnchorPosX(openBorderRightX, 0.75f));
        seq.Join(SettingBack.DOScaleX(15, 0.75f));
        seq.AppendCallback(()=> ESCState());
        
    }

    private void ESCState()
    {
        SettingPanel.SetActive(true);
        Time.timeScale = 0;

        noOpen = false;
    }

    private void SettingClose()
    {
        isMove = true;
        Time.timeScale = 1;
        SettingPanel.SetActive(false);

        Vector3 target = closePosition - transform.localPosition;



        noOpen = true;
        isMove = false;
    }
}
