using UnityEngine;
using UnityEngine.UI;

public class LockTimer : MonoBehaviour
{
    public float timeLeft = 30f;
    public Text timerText;
    public GameObject winMessage;
    public GameObject loseMessage;
    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;
        timerText.text = Mathf.CeilToInt(timeLeft).ToString();

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            GameOver(false);
        }
    }

    public void CheckGameState(int[] pins, int target)
    {
        if (pins[0] == target && pins[1] == target && pins[2] == target)
        {
            GameOver(true);
        }
    }

    void GameOver(bool win)
    {
        gameEnded = true;
        if (win)
            GameManager.Instance.GameWin();
        else
            GameManager.Instance.GameLose();
    }

    public void ResetGame()
    {
        timeLeft = 30f;
        gameEnded = false;
        winMessage.SetActive(false);
        loseMessage.SetActive(false);
    }
}