using System;
using UnityEngine;

public class PigsManager : MonoBehaviour
{
    public static PigsManager Instance {  get; private set; }

    private int pigsInPlayOnLevel;

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

    public void CountPigsInPlayOnLevel()
    {
        Debug.Log(transform.name);
        pigsInPlayOnLevel = transform.childCount;
        Debug.Log(pigsInPlayOnLevel);
    }

    public void ReducePigsInPlayOnLevel()
    {
        pigsInPlayOnLevel--;
        Debug.Log(pigsInPlayOnLevel);

        if (pigsInPlayOnLevel <= 0)
        {
            SceneController.Instance.NextLevel();
        }
    }
}
