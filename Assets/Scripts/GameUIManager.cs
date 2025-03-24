using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text lifeText;

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

    public void SetLifeText(string text) => lifeText.text = text;

    private void OnEnable() => SetPlayerHealthUIOnGameStart();

    private static void SetPlayerHealthUIOnGameStart() => GameUIManager.Instance.SetLifeText(LifeManager.Instance.CurrentLifes.ToString());
}
