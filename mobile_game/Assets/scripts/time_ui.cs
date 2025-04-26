using UnityEngine;
using TMPro;

public class time_ui : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    private float elapsedTime = 0f;
    private int highScore = 0;

    void Start()
    {
        // Önceki oturumdan kaydedilmiş en iyi skoru al
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateDisplay();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        int currentSec = Mathf.FloorToInt(elapsedTime);
        timeText.text = 
            $"Süre: {currentSec}s\nEn İyi: {highScore}s";
    }

    // Oyun bittiğinde çağrılacak
    public void SaveHighScore()
    {
        int currentSec = Mathf.FloorToInt(elapsedTime);
        if (currentSec > highScore)
        {
            highScore = currentSec;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
}