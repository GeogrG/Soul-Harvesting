using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletone : MonoBehaviour
{
    private void Awake()
    {
        SetUpSingleTone();
    }

    private void SetUpSingleTone()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
