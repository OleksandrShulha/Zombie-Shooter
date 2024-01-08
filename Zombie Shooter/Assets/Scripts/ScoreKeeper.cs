using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int curentScore = 0;

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
