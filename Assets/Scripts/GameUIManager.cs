using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private Button exitButton;

    public static GameUIManager Instance;

    private void Awake() => SetInstance();

    private void SetInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Start() => SetButtons();

    private void SetButtons()
    {
        exitButton.onClick.AddListener(() => GameManager.Instance.QuitGame());
    }

    public void SetLifeText(string text) => lifeText.text = text;

    private void OnEnable() => SetPlayerHealthUIOnGameStart();

    private static void SetPlayerHealthUIOnGameStart() => GameUIManager.Instance.SetLifeText(LifeManager.Instance.CurrentLifes.ToString());
}
