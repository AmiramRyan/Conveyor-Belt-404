using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        if (!gameManager)
        {
            Debug.LogError("No game manager found for the panel buttons");
        }
    }

    public void GoToMenu() { gameManager.GoToMenu(); }
    public void StartStoryMode() { gameManager.StartGame(GameMode.story); }
    public void StartEndlessMode() { gameManager.StartGame(GameMode.endless); }
    public void Quit() { Application.Quit(); }
}
