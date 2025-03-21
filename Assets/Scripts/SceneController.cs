using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }

    private int currentScene;
    private bool gameStarted = false;
    private int levelsInTheGame;

    private void Awake() => SetInstance();

    private void Start() => SetLevelsNumber();

    private void SetLevelsNumber() => levelsInTheGame = SceneManager.sceneCountInBuildSettings;

    private void SetInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Update() => StartGame();

    private void StartGame()
    {
        if (Input.anyKeyDown && !gameStarted)
        {
            gameStarted = true;
            SceneManager.LoadScene("MainScene");
            currentScene = SceneManager.GetActiveScene().buildIndex + 1;
            NextLevel();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
        gameStarted = false;
        Destroy(gameObject);
    }

    public void NextLevel()
    {
        SceneManager.UnloadSceneAsync(currentScene);
        currentScene++;
        if (levelsInTheGame > currentScene)
        {
            SceneManager.LoadScene(currentScene, LoadSceneMode.Additive);
            LifeManager.Instance.SetLifesToMax();
            return;
        }
        EndGame();
    }
}
