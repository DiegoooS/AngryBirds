using UnityEngine;

public class PigsManager : MonoBehaviour
{
    public static PigsManager Instance {  get; private set; }

    private int pigsInPlayOnLevel;
    private Player player;

    private void Awake() => SetInstance();

    private void SetInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Start() => CountPigsInPlayOnLevel();

    private void FindPlayerObjectOnScene() => player = FindAnyObjectByType<Player>();

    public void CountPigsInPlayOnLevel() => pigsInPlayOnLevel = transform.childCount;

    public void ReducePigsInPlayOnLevel()
    {
        pigsInPlayOnLevel--;

        if (pigsInPlayOnLevel <= 0)
        {
            ActivateNextLevel();
        }
    }

    private void ActivateNextLevel()
    {
        FindPlayerObjectOnScene();
        SceneController.Instance.NextLevel();
        player.ResetPlayerPosition();
    }
}
