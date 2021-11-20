using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : GenericSingletonClass<MonoBehaviour>
{
    public Text clockSec;
    public Text clockMin;
    private float clockSecCounter;
    private int clockMinCounter;
    public bool timerRunning;
    public GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.FindWithTag("game_manager").GetComponent<GameManager>();
        if (!gameManager)
        {
            Debug.LogError("No game manager found in timer");
        }
    }

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
                    gameManager.EndGameMode(true); //won
                }

            }
            UpdateClockUi();
        }
    }

    private void UpdateClockUi()
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

    public void SetTimer(int min, float sec)
    {
        clockSecCounter = sec;
        clockMinCounter = min;
    }

    public void EndlessTimer()
    {
        clockMin.text = "Over";
        clockSec.text = "Time";
    }
        
}
