
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class CSI_Death_Sc : MonoBehaviour
{
    public Image Background;

    private void Awake()
    {
        Background = GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
        transform.DOLocalMoveY(0 + 540, 1, false).SetEase(Ease.Unset);
        Background.DOFade(0, 1);
    }
    public void ReStartBt()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("나가는 씬 이름");
    }
}
