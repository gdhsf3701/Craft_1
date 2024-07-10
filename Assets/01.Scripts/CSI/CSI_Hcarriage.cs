using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSI_Hcarriage : MonoBehaviour
{
    
    [SerializeField]private Vector2 Goal;

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Goal, Time.fixedDeltaTime/10);
    }
}
