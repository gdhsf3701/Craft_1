using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HpbarUi : MonoBehaviour
{
    private Health _playerHealth;
    private Image _barImage;
    private Image _backBarImage;

    private float _lastHitTime;
    private bool _isChaseFill;
    private void Start()
    {
        _playerHealth = GameManager.Instance.Player.HealthCompo;

        _barImage = transform.Find("Bar").GetComponent<Image>();
        _backBarImage = transform.Find("BackBar").GetComponent<Image>();

        _playerHealth.OnHitEvent.AddListener(HandleHitEvent);

    }

    private void Update()
    {
        BackBarImage();
    }
    private void HandleHitEvent()
    {
        _lastHitTime = Time.time;
        _barImage.fillAmount = _playerHealth.GetNormalizeHealth();
        transform.DOShakePosition(0.3f, 1f, 100);
    }

    private void BackBarImage()
    {
        if (GameManager.Instance.Player == null) return;
        if (!_isChaseFill && _lastHitTime + 1f > Time.time)
            _backBarImage.DOFillAmount(_barImage.fillAmount, 0.8f).SetEase(Ease.InCubic).OnComplete(() => _isChaseFill = false);
    }
}
