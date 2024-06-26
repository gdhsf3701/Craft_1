using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cover : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    // text는 상호작용 안 텍스트 (월드스페이스 캔버스)
    private bool _isPlayer = false;

    GameObject _player;

    Rigidbody2D rd;

    SpriteRenderer renderer;
    bool hide = false;

    private void Start()
    {
        _player = GameObject.Find("Player");
        rd = _player.GetComponent<Rigidbody2D>();
        renderer = _player.GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.gameObject.SetActive(true);
        _isPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        _isPlayer = false;
        print("ha");
    }

    private void Update()
    {
        if (_isPlayer&&!hide)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //_player.layer = 0;
                renderer.color = Color.clear;
                //rd.bodyType = RigidbodyType2D.Static;
                hide = true;
            }
        }
        else if(_isPlayer && hide)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _player.layer = 7;
                renderer.color = Color.white;
                renderer.enabled = true;
                hide = false;
                rd.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
