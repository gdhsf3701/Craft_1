using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigBossPattern : MonoBehaviour
{
    Animator animator;
    GameObject[] patternRange;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {

    }
}
