using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cover : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    // text�� ��ȣ�ۿ� �� �ؽ�Ʈ (���彺���̽� ĵ����)
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
                // ��ȣ�ۿ� �� �۵��� ����
            }
        }
    }
}
