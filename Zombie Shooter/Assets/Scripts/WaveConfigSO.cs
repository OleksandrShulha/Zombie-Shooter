using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    //префаб руху
    [SerializeField] Transform pathPrefanb;
    //швидкість руху
    [SerializeField] float moveSpeed = 5f;

    //метод який повертає швидкість руху
    public float GetMoveSpeed()
    {
        return moveSpeed; 
    }

    //метод з якого отримуємо першу точку початку руху
    public Transform GetStartingPoint()
    {
        return pathPrefanb.GetChild(0);
    }


    //методо який проходиться по вім точка шляху та добавляє їх в новий список
    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach(Transform child in pathPrefanb)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
}
