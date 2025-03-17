using UnityEngine;

public class PigsManager : MonoBehaviour
{
    public static PigsManager Instance {  get; private set; }

    private int pigsInPlayOnLevel;
    private Player player;

    private void Awake()
    {
        SetInstance();
    }

    private void SetInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Start()
    {
        CountPigsInPlayOnLevel();
    }

    private void SetPlayer()
    {
        player = FindAnyObjectByType<Player>();
        Debug.Log(player.name);
    }

    public void CountPigsInPlayOnLevel()
    {
        Debug.Log(transform.name);
        pigsInPlayOnLevel = transform.childCount;
        Debug.Log(pigsInPlayOnLevel);
    }

    public void ReducePigsInPlayOnLevel()
    {
        pigsInPlayOnLevel--;

        if (pigsInPlayOnLevel <= 0)
        {
            SetPlayer();
            player.ResetPlayerPosition();
            SceneController.Instance.NextLevel();
        }
    }
}
