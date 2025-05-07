using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockPickingGame : MonoBehaviour
{
    // Настройки игры
    public int[] targetPins = {5, 5, 5};
    public float initialTime = 30f;
    
    // UI элементы
    public TMPro.TextMeshProUGUI[] pinTexts;
    public TMPro.TextMeshProUGUI timerText;
    public GameObject winPanel;
    public GameObject losePanel;
    public Button resetButton;
    
    // Настройки фона
    public Image backgroundImage;
    public Sprite defaultBackground;
    public Sprite winBackground;

    // Игровые переменные
    private int[] currentPins = new int[3];
    private float currentTime;
    private bool gameActive = true;

    void Start()
    {
        InitializeGame();
        resetButton.onClick.AddListener(ResetGame);
        
        // Устанавливаем фон по умолчанию
        if (backgroundImage != null && defaultBackground != null)
        {
            backgroundImage.sprite = defaultBackground;
        }
    }

    void Update()
    {
        if (!gameActive) return;
        
        currentTime -= Time.deltaTime;
        timerText.text = "Время: " + Mathf.Max(0, Mathf.Ceil(currentTime)).ToString();
        
        if (currentTime <= 0)
        {
            LoseGame();
        }
    }

    private void InitializeGame()
    {
        // Случайные начальные значения пинов
        for (int i = 0; i < 3; i++)
        {
            currentPins[i] = Random.Range(0, 10);
            UpdatePinText(i);
        }
        
        currentTime = initialTime;
        gameActive = true;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void ResetGame()
    {
        InitializeGame();
        
        // Возвращаем обычный фон
        if (backgroundImage != null && defaultBackground != null)
        {
            backgroundImage.sprite = defaultBackground;
        }
    }

    public void UseTool(int[] toolEffects)
    {
        if (!gameActive) return;
        
        for (int i = 0; i < 3; i++)
        {
            currentPins[i] = Mathf.Clamp(currentPins[i] + toolEffects[i], 0, 10);
            UpdatePinText(i);
        }
        
        CheckWinCondition();
    }

    private void UpdatePinText(int pinIndex)
    {
        pinTexts[pinIndex].text = currentPins[pinIndex].ToString();
    }

    private void CheckWinCondition()
    {
        bool win = true;
        for (int i = 0; i < 3; i++)
        {
            if (currentPins[i] != targetPins[i])
            {
                win = false;
                break;
            }
        }
        
        if (win)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        gameActive = false;
        winPanel.SetActive(true);
        
        // Меняем фон на победный
        if (backgroundImage != null && winBackground != null)
        {
            backgroundImage.sprite = winBackground;
        }
    }

    private void LoseGame()
    {
        gameActive = false;
        losePanel.SetActive(true);
    }

    // Методы для кнопок инструментов
    public void UseDrill() => UseTool(new int[] {1, -1, 0});
    public void UseHammer() => UseTool(new int[] {-1, 2, -1});
    public void UsePick() => UseTool(new int[] {-1, 1, 1});
}