using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TextManager : MonoBehaviour
{
    private StageTimeLimit time;
    [SerializeField] private TMP_Text timeText;

    
    private void Start()
    {
        time= FindObjectOfType<StageTimeLimit>();
        timeText.text = $"Remaining Time:{time.Time}(second)";
        if (time != null)
        {
            time.OnNowTimeChanged += HandleNowTimeChanged;
        }
    }

    private void HandleNowTimeChanged(int newTime)
    {
        timeText.text = $"Remaining Time:{time.Time - newTime}(second)";
    }
    
    private void OnDestroy()
    {
        if (time != null)
        {
            time.OnNowTimeChanged -= HandleNowTimeChanged;
        }
    }
}
