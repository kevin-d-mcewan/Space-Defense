using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{

    [Header("Health")]
    [SerializeField] Slider healthSlider;                   // Object on the UI
    [SerializeField] Health playerHealth;                   // Access to Player Health


    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;                                // Used to grab current score


    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        // Get the Players Max Health before game starts
        healthSlider.maxValue = playerHealth.GetHealth();
        
    }

    
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        // Must parse it to a string bc its an int
        // The '000...'s are to add leading 0's to the score and the score will just be added to it
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("000000000");
    }
}
