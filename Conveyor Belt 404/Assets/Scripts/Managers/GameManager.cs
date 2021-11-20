using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode
{
    story,
    endless
}

public class GameManager : GenericSingletonClass_GameManager<MonoBehaviour>
{
    public ScoreManager scoreManager;
    public SpawnManager spawnManager;
    public Timer timer;
    public GameObject infoPanel;
    public GameObject mainMenuPanel;
    public GameObject gameUiPanel;
    public GameMode currentGameMode;

    
    public void StartGame(GameMode newMode)
    {
        switch (newMode)
        {
            case GameMode.story:
                StartStoryMode();
                break;
            case GameMode.endless:
                StartEndlessMode();
                break;
            default:
                Debug.LogError("Mode not available");
                break;
        }
    }

    public void GoToMenu()
    {
        //loadScene
        SceneManager.LoadScene("StartMenu");
        //set up canvas
        infoPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        gameUiPanel.SetActive(false);
    }

    private void StartStoryMode()
    {
        currentGameMode = GameMode.story;
        timer.SetTimer(0, 15);
        spawnManager.SetSpawner(1, 3);
        scoreManager.SetScoreManager(25,75);
        //loadScene
        SceneManager.LoadScene("MainGame");
        //set up canvas
        infoPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        gameUiPanel.SetActive(true);
        //activate the timer and spawner and score
        timer.timerRunning = true;
        spawnManager.spawnerActive = true;
        scoreManager.scoreManagerActive = true;
    }

    private void StartEndlessMode()
    {
        currentGameMode = GameMode.endless;
        timer.EndlessTimer();
        //set endles spawner
        scoreManager.SetScoreManager(25, 75);
        //load scene
        SceneManager.LoadScene("MainGame");
        //set up canvas
        infoPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        gameUiPanel.SetActive(true);
        //activate spawner
        spawnManager.spawnerActive = true;
        scoreManager.scoreManagerActive = true;
    }

    public void EndGameMode(bool win)
    {
        timer.timerRunning = false;
        spawnManager.spawnerActive = false;
        scoreManager.scoreManagerActive = false;

        if (win)
        {
            //load scene and give win text
            //win text
            infoPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
            gameUiPanel.SetActive(false);
        }
        else
        {
            //load scene and give lose text
            //lose text
            infoPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
            gameUiPanel.SetActive(false);
        }
    }

    public void ChangeMode(GameMode newMode) 
    {
        currentGameMode = newMode;
    }
}
