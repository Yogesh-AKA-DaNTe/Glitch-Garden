using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    // Variables for setting lives
    [SerializeField] float baseLives = 5;
    float lives;
    Text livesText;

    void Start()
    {
        // Initial setup for lives
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    // Function to update lives
    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    // Function to take lives
    public void TakeLife()
    {
        lives -= 1;
        UpdateDisplay();
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
