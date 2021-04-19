using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTUEElement : MonoBehaviour
{
    void Update()
    {
        gameObject.SetActive(SaveData.ftue);
    }
}
