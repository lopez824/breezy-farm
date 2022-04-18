using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Functions as a countdown timer
/// </summary>
public class Timer : MonoBehaviour
{
    public static float timeRemaining = 90;      // measured in seconds
    public bool timerPaused;
    private bool isTimerRunning = false;

    [SerializeField]
    private TextMeshProUGUI timerText;

    void Start()
    {
        isTimerRunning = true;
    }

    /// <summary>
    /// Converts time in seconds to Minute:Seconds
    /// </summary>
    private void DisplayTime(float time)
    {
        time += 1;      // offset for flooring
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0 && timerPaused == false)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isTimerRunning = false;
            }
        }
    }
}
