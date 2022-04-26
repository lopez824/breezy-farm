using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public Timer timer;
    public TextMeshProUGUI bestTimeText;
    private GameObject[] piggies;
    private int piggyCount = 0;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("BestTime"))
            PlayerPrefs.SetString("BestTime", "0:00");
        if (!PlayerPrefs.HasKey("NewRecord"))
            PlayerPrefs.SetFloat("NewRecord", Mathf.Infinity);
        bestTimeText.text = PlayerPrefs.GetString("BestTime");
        piggies = GameObject.FindGameObjectsWithTag("Piggy");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Piggy")
        {
            AI ai = other.gameObject.GetComponent<AI>();
            piggyCount++;
            ai.inPen = true;

            if (piggyCount == piggies.Length)
            {
                float finalTime = timer.currentTime;
                string finalTimeString = timer.GetDisplayTime(finalTime);
                if (finalTime < PlayerPrefs.GetFloat("NewRecord"))
                {
                    PlayerPrefs.SetFloat("NewRecord", finalTime);
                    PlayerPrefs.SetString("BestTime", finalTimeString);
                    bestTimeText.text = PlayerPrefs.GetString("BestTime");
                }
            }
        }
    }
}
