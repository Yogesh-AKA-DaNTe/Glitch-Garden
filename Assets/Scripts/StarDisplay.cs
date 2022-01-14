using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    // Variables for storing stars and displaying them
    [SerializeField] int stars = 100;
    Text starText;

    void Start()
    {
        // Sets Star Text and updates display
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    // Function for updating the Star Text
    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    // Function for adding stars and updating the display
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    // Function to check if you have enough stars
    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    // Function for spending stars and updating the display
    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }
}
