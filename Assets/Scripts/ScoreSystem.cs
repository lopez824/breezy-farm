using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public Timer timer;
    public TextMeshProUGUI personalRecordText;
    public TextMeshProUGUI worldRecordText;
    private GameObject[] piggies;
    private int piggyCount = 0;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("WorldDisplay"))
            PlayerPrefs.SetString("WorldDisplay", "0:00");
        if (!PlayerPrefs.HasKey("WorldRecord"))
            PlayerPrefs.SetFloat("WorldRecord", Mathf.Infinity);
        personalRecordText.text = "0:00";
        worldRecordText.text = PlayerPrefs.GetString("WorldDisplay");
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
                personalRecordText.text = finalTimeString;
                if (finalTime < PlayerPrefs.GetFloat("WorldRecord"))
                {
                    PlayerPrefs.SetFloat("WorldRecord", finalTime);
                    PlayerPrefs.SetString("WorldDisplay", finalTimeString);
                    worldRecordText.text = PlayerPrefs.GetString("WorldDisplay");
                }
            }
        }
    }
}
