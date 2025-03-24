using System;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;
    [SerializeField] int maxLifes = 5;
    public int CurrentLifes { get; private set; }

    private void Awake() => SetInstance();

    private void SetInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    public void ReduceLife()
    {
        CurrentLifes--;
        GameUIManager.Instance.SetLifeText(CurrentLifes.ToString());
    }

    public void SetLifesToMax()
    {
        CurrentLifes = maxLifes;
        GameUIManager.Instance?.SetLifeText(CurrentLifes.ToString());
    }

    public void CheckIfGameOver()
    {
        if (CurrentLifes <= 0) SetGameOver();
    }

    private void SetGameOver() => SceneController.Instance.EndGame();
}
