using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0.0f;
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                /* To create enemies at Runtime we need to use the function "Instantiate();"


                / To instantiate an enemy at index 0 it would be
                /  Instantiate(currentWave.GetEnemyPrefab(0));

                / The 'transform' by itself is for the Parent so by just putting transform its giving the spawners location by doing that

                  Below will instantiate an enemy at the Path location starting position     */

                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWaypoint().position,
                                Quaternion.Euler(0, 0, 180),
                                transform);
                    // CoRoutine below runs above code waits for a couple of seconds(from GetRandomSpawnTime) and then comes back to SpawnEnemies to see if
                    // The loop has been completed or needs to go again

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }

        } while (isLooping == true);
       


    }

    
    
}
