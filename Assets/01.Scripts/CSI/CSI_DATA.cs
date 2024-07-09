using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSI_DATA : MonoBehaviour
{
    public float ItemSpawnColltime;

    public IEnumerator Colltimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

        }
    }
}
 