using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    private float _playTime;

    private void Start()
    {
        _playTime = SaveManager.Instance.saveData.playTime;
        PlayerManager.Instance.PlayerTrm.position = SaveManager.Instance.saveData.spawnPos;
    }

    private void Update()
    {
        _playTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.B))
        {
            SavingData();
        }
    }
    
    
    private void SavingData()
    {
        SaveManager.Instance.saveData.playTime = _playTime;
        SaveManager.Instance.saveData.playDate = DateTime.Now.ToString("yyyy - MM - dd - HH");
        SaveManager.Instance.saveData.playerHp = PlayerManager.Instance.Player.HealthCompo.CurrentHealth;
        SaveManager.Instance.saveData.spawnPos = PlayerManager.Instance.PlayerTrm.position;
        
        SaveManager.Instance.SaveDataToJson();
    }
}
