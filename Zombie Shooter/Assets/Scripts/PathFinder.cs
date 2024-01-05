using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> wayPoint;
    int wayPointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();  
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurentWave();
        wayPoint = waveConfig.GetWayPoints();
        transform.position = wayPoint[wayPointIndex].position;
    }


    void Update()
    {
        FallowPatch();
    }

    private void FallowPatch()
    {
        //якщо поточний індекс менше за кількість точок шляху
        if(wayPointIndex < wayPoint.Count)
        {
            //заносимо позицію куди рухатись
            Vector3 targetPosition = wayPoint[wayPointIndex].position;
            //швидкість руху
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            //переміщаємо наш обєкт з своєї позиції на нову з відповідною швидкість
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if(transform.position == targetPosition)
            {
                wayPointIndex++; 
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
