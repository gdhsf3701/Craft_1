using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMove : MonoBehaviour
{
    bool noOpen = true;
    bool isMove = false;

    Vector3 closePosition = new Vector3(0, 0, 0);
    Vector3 openPosition = new Vector3(0, -1040, 0);

    float settingSpeed = 1500f;

    float Distance = 10f;

    private GameObject SettingPanel;
    private void Awake()
    {
        SettingPanel = transform.GetChild(1).gameObject;
        SettingPanel.SetActive(false);
    }

    private void Update()
    {
        OnOffSetting();
    }

    public void OnOffSetting()
    {
        if (noOpen && !isMove && Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(SettingOpen());
        }
        else if (!noOpen && !isMove && Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(SettingClose());
        }
    }

    IEnumerator SettingOpen()
    {
        isMove = true;
        Time.timeScale = 0;
        while (Vector3.Distance(openPosition, transform.localPosition) >= Distance)
        {
            Vector3 target = openPosition - transform.localPosition;
            transform.localPosition += target.normalized * settingSpeed * Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localPosition = openPosition;
        SettingPanel.SetActive(true);
        noOpen = false;
        isMove = false;
    }

    IEnumerator SettingClose()
    {
        isMove = true;
        Time.timeScale = 1;
        SettingPanel.SetActive(false);
        while (Vector3.Distance(closePosition, transform.localPosition) >= Distance)
        {
            Vector3 target = closePosition - transform.localPosition;
            transform.localPosition += target.normalized * settingSpeed * Time.unscaledDeltaTime;
            yield return null;
        }
        transform.localPosition = closePosition;
        noOpen = true;
        isMove = false;
    }
}
