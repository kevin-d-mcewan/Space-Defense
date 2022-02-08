using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;

    //Waypoint currently on; Defaults to 0 (first wavepoint in List)
    int waypointIndex;

    private void Awake()
    {
        // This makes a ref of enemySpawner so that its items can be used in this script
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        // This makes the waveConfig var in this script the same as the one in EnemySpawner.cs
        waveConfig = enemySpawner.GetCurrentWave();

        // Populate list of wavepoints
        waypoints = waveConfig.GetWaypoints();

        //Move Enemy to first waypoint in the path
        transform.position = waypoints[waypointIndex].position;

    }

    
    void Update()
    {
        // Each frame we want to move closer to the next wavepoint in the list
        FollowPath();

    }

    private void FollowPath()
    {
        // If we are not at last wavepoint in list go to next wavepoint
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }

        }

        else
        {
            Destroy(gameObject);
        }
    }
}

