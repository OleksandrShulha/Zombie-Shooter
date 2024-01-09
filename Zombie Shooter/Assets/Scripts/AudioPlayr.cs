using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayr : MonoBehaviour
{
    private void Awake()
    {
        ManageSinglton();
    }

    private void ManageSinglton()
    {
        int instanseCount = FindObjectsOfType(GetType()).Length;
        if (instanseCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
