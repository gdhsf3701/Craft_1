using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad Instance = null;

    public static int SaveSlotNum;
    public static int AreaList;

    static int nowTime;
    private string Stage;
    private int Area;

    public bool end;//���θ޴� ȭ��� ���ų� ������ �����Ҷ�
    public bool stop = false; // �ð������� ���ߴ� ��Ȳ ����â,�ƽ�

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void LoadSlot() 
    {
        nowTime = PlayerPrefs.GetInt($"SlotTime{SaveSlotNum}", 0);
        Stage = PlayerPrefs.GetString($"SlotStage{SaveSlotNum}", $"Stage{0}");
        Area = PlayerPrefs.GetInt($"SlotArea{AreaList}", 0);

        StartCoroutine(TimeChack());

        SceneManager.LoadScene(Stage);
    }

    IEnumerator TimeChack()
    {
        while (!end)
        {
            yield return new WaitForSeconds(1);
            if (!stop)
            {
                nowTime++;
            }
        }
        PlayerPrefs.SetString($"SlotStage{SaveSlotNum}", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt($"SlotTime{SaveSlotNum}", nowTime);
    }
}
