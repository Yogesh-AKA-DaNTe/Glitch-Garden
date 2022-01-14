using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    // Variables related to game timer
    [Tooltip("Our Level Timer in Seconds")]
    [SerializeField] float levelTime = 10;
    bool triggeredLevelFinished = false;

    void Update()
    {
        // Keeps increasing the slider which shows the level timer and triggers level finished when timer expires
        if (triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
