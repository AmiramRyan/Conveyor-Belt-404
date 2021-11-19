using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreTxt; // the score txt element
    [SerializeField] private Text strikeText; 
    [SerializeField] private List<GameObject> lives; //img of the livs
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private Timer timer;
    public int correctBarrelValue; //positive score
    public int wrongBarrelValue; //negetive score 

    private int currentLives;
    private int currentScore;

    void Start()
    {
        ResetValues();
        spawnManager.spawnerActive = true;
        timer.timerRunning = true;

    }

    void Update()
    {
        scoreTxt.text = currentScore + " $";
        strikeText.text = ""+currentLives;
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        if(amount < 0)
        {
            LoseLife();
        }
    }

    private void LoseLife()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            currentLives = 0;
            lives[currentLives].SetActive(false);

            //lose stuff
            spawnManager.spawnerActive = false;
            //go back to menu
        }
        else 
        { 
            lives[currentLives].SetActive(false); 
        }
    }

    public void ResetValues()
    {
        //reset stuff
        currentScore = 0;
        scoreTxt.text = 0 + "$";
        currentLives = lives.Count;
        for (int i = 0; i< currentLives - 1; i++)
        {
            lives[i].SetActive(true);
        }
    }

}
