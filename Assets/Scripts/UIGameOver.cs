using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    // TextMeshPro UI Element
    [SerializeField] TextMeshProUGUI scoreText;
    // ref to ScoreKeeper
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        // Setting Ref = to gameObj ScoreKeeper(PreFab) in this scene
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        // Will be the place to keep score (from the GameObj we drag into the [SerializeField]
        scoreText.text = "You Scored:\n" + scoreKeeper.GetCurrentScore();
    }
}
