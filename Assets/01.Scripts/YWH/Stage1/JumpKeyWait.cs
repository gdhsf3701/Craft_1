using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKeyWait : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChatSystem.Instance.TypCoStart("금자월", "또.. 이런건가?", 0.2f);
    }

}
