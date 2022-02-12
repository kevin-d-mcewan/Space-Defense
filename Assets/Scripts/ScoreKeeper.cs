using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore;

    static ScoreKeeper instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (instance != null)
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

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void ModifyScore(int value)
    {

        currentScore += value;
        
        // score can't go below 0
        Mathf.Clamp(currentScore, 0, int.MaxValue);
        // Check currentScore is working
        Debug.Log(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
       
    }


}
