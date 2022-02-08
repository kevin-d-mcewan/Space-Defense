using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float timeBetweenEnemySpawns = 1.0f;
    [SerializeField] float spawnTimeVariance = 0.0f;
    [SerializeField] float minSpawnTime = 0.2f;

    
    
    // Gets the 1st index in the set of Waypoints
    public Transform GetStartingWaypoint()
    {
        // Returns the 1 index in the "pathPrefab" List
        return pathPrefab.GetChild(0);
    }

    // Gets all the waypoints in each waypoint list
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }


    // Getter for MoveSpeed
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    // This is Giving each instance of each index in the list (i.e. [0], [1], [2], [3]...)
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];    
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }

}
