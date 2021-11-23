using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameMode
{
    story,
    endless
}

public class GameManager : GenericSingletonClass_GameManager<MonoBehaviour>
{
    [Header("Public managers and UI panels")]
    public ScoreManager scoreManager;
    public SpawnManager spawnManager;
    public Timer timer;
    public GameObject infoPanel;
    public GameObject mainMenuPanel;
    public GameObject gameUiPanel;
    public Text highScoreUiTextMain;
    public Text highScoreUiTextInfo;
    public HighScoreScript highscoreVal;
    public Text EndText;

    private GameMode currentGameMode;
    [Header("Game Stats")]
    [SerializeField] private int timerMin;
    [SerializeField] private float timerSec;
    [SerializeField] private float fastestSpawnRateStory;
    [SerializeField] private float slowestSpawnRateStory;
    [SerializeField] private float fastestSpawnRateEndless;
    [SerializeField] private float slowestSpawnRateEndless;
    [SerializeField] private string loseText;
    [SerializeField] private string winText;

    private static int goodBarrelSortPointValue = 25;
    private static int badBarrelSortPointValue = 50;

    public override void Awake()
    {
        base.Awake();
        highScoreUiTextMain.text = "High Score: " + highscoreVal.runTimeValueScore;
        highScoreUiTextInfo.text = "High Score: " + highscoreVal.runTimeValueScore;
    }

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
        timer.SetTimer(timerMin, timerSec);
        spawnManager.SetSpawner(fastestSpawnRateStory, slowestSpawnRateStory);
        scoreManager.SetScoreManager(goodBarrelSortPointValue, badBarrelSortPointValue);
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
        spawnManager.SetSpawner(slowestSpawnRateEndless, fastestSpawnRateEndless);
        scoreManager.SetScoreManager(goodBarrelSortPointValue, badBarrelSortPointValue);
        //load scene
        SceneManager.LoadScene("MainGame");
        //set up canvas
        infoPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        gameUiPanel.SetActive(true);
        //activate spawner
        spawnManager.spawnerActive = true;
        spawnManager.startEndlessSpawn();
        scoreManager.scoreManagerActive = true;
    }

    public void EndGameMode(bool win)
    {
        highscoreVal.runTimeValueScore = scoreManager.currentScore;
        timer.timerRunning = false;
        spawnManager.spawnerActive = false;
        scoreManager.scoreManagerActive = false;
        //set score
        highScoreUiTextMain.text = "High Score: " + highscoreVal.runTimeValueScore;
        highScoreUiTextInfo.text = "High Score: " + highscoreVal.runTimeValueScore;

        if (win)
        {
            //load scene and give win text
            EndText.text = winText;
            
            //win text
            infoPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
            gameUiPanel.SetActive(false);
        }
        else
        {
            //lose text
            EndText.text = loseText;
            //load scene and give lose text
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
