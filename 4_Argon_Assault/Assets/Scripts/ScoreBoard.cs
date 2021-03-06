using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "0";
    }

    public void IncreaseScore(int amountToIncrease) // Public means it is accessable to use in all scripts in the current project.
    {
        score += amountToIncrease;
        scoreText.text = score.ToString(); // Convetring our score which is of int type to str type and sending the text to TMPro.
    }
}
