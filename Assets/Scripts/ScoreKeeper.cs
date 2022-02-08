using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore;


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
