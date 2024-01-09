using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int curentScore = 0;

    static ScoreKeeper instance;

    private void Awake()
    {
        ManageSinglton();

    }

    private void ManageSinglton()
    {
        
        if (instance != null && SceneManager.GetActiveScene().buildIndex != 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetCurentScore()
    {
        return curentScore;
    }

    public void SetScore(int score)
    {
        curentScore += score;
    }

    public void ResetScore()
    {
        curentScore = 0;
    }
}
