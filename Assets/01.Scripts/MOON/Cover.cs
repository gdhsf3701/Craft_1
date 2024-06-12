using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cover : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    // text는 상호작용 안 텍스트 (월드스페이스 캔버스)
    private bool _isPlayer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.gameObject.SetActive(true);
        _isPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        _isPlayer = false;
    }

    private void Update()
    {
        if (_isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // 상호작용 시 작동될 내용
            }
        }
    }
}
