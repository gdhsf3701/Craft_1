using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestMaster : MonoBehaviour
{
    [SerializeField]
    private List<string> descList = new List<string>();
    [SerializeField]
    private List<string> nameList = new List<string>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            ChatSystem.Instance.TypCoStart(nameList[0], descList[0], 0.07f);
        }
    }
}
