using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameStart;
    public int score;
    public int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public float crystalSpeedMultiplier = 0.2f;
    CharMovement charMovement;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        gameStart = true;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "High Score: " + highScore.ToString();

        }
    }

}
