using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public LockController lockController;
    public LockTimer lockTimer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        lockController.ResetLock();
        lockTimer.ResetGame();
    }

    public void GameWin()
    {
        Debug.Log("You Win!");
    }

    public void GameLose()
    {
        Debug.Log("You Lose!");
    }
}