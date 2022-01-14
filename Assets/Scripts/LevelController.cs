using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Variables for controlling the flow of level
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    void Start()
    {
        // Sets WinLabel and LoseLabel to inactive
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    // Function to signal that the level is finished
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    // Function to stop the spawners
    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    // Function to increase the number of attackers after each spawn
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    // Function to decrease the number of attackers after each attacker is killed
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    // Coroutine for handling the Win condition
    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(4f);
        FindObjectOfType<LevelLoad>().LoadNextScene();
    }

    // Function for handling the Lose condition
    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
}
