using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using EasySave.Json;
using UnityEngine.SceneManagement;

public class SceneName
{
    public const string Start = "StartScene";
    public const string Stage0 = "Stage0Scene";
    public const string Stage1 = "Stage1Scene";
    public const string Stage2 = "Stage2Scene";
    public const string Stage3 = "Stage3Scene";
    public const string Stage4 = "Stage4Scene";
    public const string Stage5 = "Stage5Scene";
    public const string End = "EndScene";
}
public class SaveManager : MonoBehaviour
{
    public SaveData saveData;
    public static SaveManager Instance;
    
    public string dataPath = "SaveData1";
    
    private static readonly string LocalPath = Application.dataPath + "/SaveFolder/";
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
        saveData = new SaveData();

        SceneManager.sceneLoaded += HandleSceneChaneEvent;
    }
 
    private void HandleSceneChaneEvent(Scene arg0, LoadSceneMode arg1)
    {
        //씬 바뀌었을때 해줘야할 행동들
        
    }

    public void SaveDataToJson()
    {
        EasyToJson.ToJson(saveData,dataPath,true);
    } 

    public void JsonToSaveData(string jsonFileName)
    { 
       string path = GetFilePath(jsonFileName);
       if (!File.Exists(path))
       {
           Debug.Log("파일이 존재하지 않습니다.");
           Debug.Log("파일을 생성합니다.");
           SaveData defaultObj = new SaveData();
           EasyToJson.ToJson(defaultObj, jsonFileName, true);
           saveData = defaultObj;
       }
       string json = File.ReadAllText(path);
       SaveData obj = JsonUtility.FromJson<SaveData>(json);
       saveData = obj;
    }

    public SaveData JsonToData(string jsonFileName)
    {
        string path = GetFilePath(jsonFileName);
        if (!File.Exists(path))
        {
            Debug.Log("파일이 존재하지 않습니다.");
            Debug.Log("파일을 생성합니다.");
            SaveData defaultObj = new SaveData();
            EasyToJson.ToJson(defaultObj, jsonFileName, true);
            return defaultObj;
        }
        string json = File.ReadAllText(path);
        SaveData obj = JsonUtility.FromJson<SaveData>(json);
        return obj;
    }
    public string GetFilePath(string fileName)
    {
        return Path.Combine(LocalPath, $"{fileName}.json");
    }
}
