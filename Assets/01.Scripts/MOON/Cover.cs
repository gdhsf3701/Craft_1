using Cinemachine;
using DG.Tweening;
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
    CinemachineVirtualCamera camera;

    SpriteRenderer renderer;
    bool hide = false;
    float maxCameraSize = 5f;
    float minCameraSize = 2.5f;

    Coroutine coroutine;

    private void Start()
    {
        _player = GameObject.Find("Player");
        camera = FindAnyObjectByType<CinemachineVirtualCamera>();
        rd = _player.GetComponent<Rigidbody2D>();
        renderer = _player.GetComponentInChildren<SpriteRenderer>();
        maxCameraSize -= 0.1f;
        minCameraSize += 0.1f;
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
    }

    private void Update()
    {
        if (_isPlayer&&!hide)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _player.layer = 0;
                renderer.color = Color.clear;
                rd.bodyType = RigidbodyType2D.Static;
                hide = true;
                _player.transform.position = new Vector3(transform.position.x,_player.transform.position.y,_player.transform.position.z );
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                    coroutine = null;
                }
                coroutine = StartCoroutine(Zoom());
            }
        }
        else if(hide)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _player.layer = 7;
                renderer.color = Color.white;
                hide = false;
                rd.bodyType = RigidbodyType2D.Dynamic;
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                    coroutine = null;
                }
                coroutine = StartCoroutine(Out());
            }
        }
    }
    IEnumerator Zoom()
    {
        while(camera.m_Lens.OrthographicSize >= minCameraSize)
        {
            camera.m_Lens.OrthographicSize -= 0.1f;
            yield return null;
        }
    }
    IEnumerator Out()
    {
        while (camera.m_Lens.OrthographicSize <= maxCameraSize)
        {
            camera.m_Lens.OrthographicSize += 0.1f;
            yield return null;
        }
    }
}
