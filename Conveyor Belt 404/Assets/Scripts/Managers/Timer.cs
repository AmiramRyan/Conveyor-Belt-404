using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text clockSec;
    public Text clockMin;
    [SerializeField] private float clockSecCounter;
    [SerializeField] private int clockMinCounter;
    [SerializeField] private SpawnManager spawnManager;
    public bool timerRunning;

    void Update()
    {
        if (timerRunning)
        {
            clockSecCounter -= Time.deltaTime;
            if (clockSecCounter <= 0)
            {
                if (clockMinCounter > 0)
                {
                    clockMinCounter--; //min is up
                    clockSecCounter = 60f;
                }
                else
                {
                    //time is up!
                    spawnManager.spawnerActive = false;
                    timerRunning = false;
                }

            }
            UpdateClockUi();
        }
    }

    public void UpdateClockUi()
    {
        if ((clockMinCounter / 10) <= 0) //single digit
        {
            clockMin.text = "0" + (int)clockMinCounter;
        }
        else 
        {
            clockMin.text = "" + (int)clockMinCounter;
        }
        if ((clockSecCounter / 10) <= 0) //single digit
        {
            clockSec.text = "0" + (int)clockSecCounter;
        }
        else
        {
            clockSec.text = "" + (int)clockSecCounter;
        }
    }
        
}
