using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveData : MonoBehaviour
{
    public void Load1()
    {
        SaveLoad.SaveSlotNum = 1;
        SaveLoad.Instance.end = true;
        SaveLoad.Instance.LoadSlot();
    }
    public void Load2()
    {
        SaveLoad.SaveSlotNum = 2;
        SaveLoad.Instance.end = true;
        SaveLoad.Instance.LoadSlot();
    }
    public void Load3()
    {
        SaveLoad.SaveSlotNum = 3;
        SaveLoad.Instance.end = true;
        SaveLoad.Instance.LoadSlot();
    }
    public void Load4()
    {
        SaveLoad.SaveSlotNum = 4;
        SaveLoad.Instance.end = true;
        SaveLoad.Instance.LoadSlot();
    }
    public void Load5()
    {
        SaveLoad.SaveSlotNum = 5;
        SaveLoad.Instance.end = true;
        SaveLoad.Instance.LoadSlot();
    }
}
