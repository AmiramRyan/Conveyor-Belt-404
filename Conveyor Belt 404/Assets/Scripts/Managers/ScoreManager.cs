using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : GenericSingletonClass_Score<MonoBehaviour>
{
    public GameManager gameManager;
    [SerializeField] private Text scoreTxt; // the score txt element
    [SerializeField] private Text strikeText; 
    [SerializeField] private List<GameObject> lives; //img of the livs
    public int correctBarrelValue; //positive score
    public int wrongBarrelValue; //negetive score 
    public bool scoreManagerActive;
    private int currentLives;
    private int currentScore;


    void Start()
    {
        gameManager = GameObject.FindWithTag("game_manager").GetComponent<GameManager>();
        if(!gameManager)
        {
            Debug.LogError("No game manager found in score manager");
        }
    }

    void Update()
    {
        if (scoreManagerActive)
        {
            scoreTxt.text = currentScore + " $";
            strikeText.text = "" + currentLives;
        }
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
            gameManager.EndGameMode(false); //lose
        }
        else 
        { 
            lives[currentLives].SetActive(false); 
        }
    }

    private void ResetValues()
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

    public void SetScoreManager(int positivePointsAmount, int negetivePointsAmount)
    {
        correctBarrelValue = positivePointsAmount;
        wrongBarrelValue = negetivePointsAmount * -1;
        ResetValues();
    }
}
