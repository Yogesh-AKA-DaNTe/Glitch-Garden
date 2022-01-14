using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    // Variable for storing the star cost of each defender
    [SerializeField] int starCost = 100;

    // Function for adding stars by a given amount
    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    // Function to get the star cost of each defender
    public int GetStarCost()
    {
        return starCost;
    }
}
