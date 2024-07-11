using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using EasySave.Json;


public class SaveManager : MonoSingleton<SaveManager>
{
    public SaveData saveData;
    
    public string dataPath = "SaveData";
    
    private static readonly string LocalPath = Application.dataPath + "/SaveFolder/";

    private void Awake()
    {
        saveData = new SaveData();
        
        JsonToSaveData(dataPath);
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
           Debug.Log(defaultObj);
           EasyToJson.ToJson(defaultObj, jsonFileName, true);
           saveData = defaultObj;
       }
       string json = File.ReadAllText(path);
       SaveData obj = JsonUtility.FromJson<SaveData>(json);
       saveData = obj;
    }
    private static string GetFilePath(string fileName)
    {
        return Path.Combine(LocalPath, $"{fileName}.json");
    }
}
