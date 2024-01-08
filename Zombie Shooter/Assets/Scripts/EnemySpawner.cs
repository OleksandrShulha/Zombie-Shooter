using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfig;
    WaveConfigSO curentWave;
    bool isSpawn = true;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public WaveConfigSO GetCurentWave()
    {
        return curentWave;
    }

    IEnumerator SpawnEnemy()
    {
        while (isSpawn)
        {
            foreach (WaveConfigSO wave in waveConfig)
            {
                curentWave = wave;
                for (int i = 0; i < curentWave.GetEnemyCount(); i++)
                {
                    //створюємо ворога за індексом в початковій точці шляху
                    Instantiate(curentWave.GetEnemyPrefabs(i), curentWave.GetStartingPoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(1f);
                }
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
