using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBorder : MonoBehaviour
{
    private GameObject SettingBorderLeft;
    private GameObject SettingBorderRight;
    private void Awake()
    {
        SettingBorderLeft = transform.GetChild(0).gameObject;
        SettingBorderRight = transform.GetChild(1).gameObject;
    }
}
