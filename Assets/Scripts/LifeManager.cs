using System;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;
    [SerializeField] int maxLifes = 5;
    private int currentLifes;

    private void Awake() => SetInstance();

    private void SetInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Start() => SetLifesToMax();

    public void ReduceLife()
    {
        currentLifes--;
    }

    public void SetLifesToMax() => currentLifes = maxLifes;

    public void CheckIfGameOver()
    {
        if (currentLifes <= 0) SetGameOver();
    }

    private void SetGameOver() => SceneController.Instance.EndGame();
}
