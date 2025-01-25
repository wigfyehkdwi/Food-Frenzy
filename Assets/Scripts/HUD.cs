using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public Level level;

    public TextMeshProUGUI remainingText;
    public TextMeshProUGUI remainingSubtext;
    public TextMeshProUGUI targetText;
    public TextMeshProUGUI targetSubtext;
    public TextMeshProUGUI scoreText;

    public Image[] stars;

    private int starIndex;
    private bool isGameOver;

    private void Start()
    {
        UpdateStars();
    }

    public void UpdateStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = i == starIndex;
        }
    }

    public void SetScore(int score)
    {

        scoreText.text = score.ToString();

        if (score >= level.score3Star) starIndex = 3;
        else if (score >= level.score2Star) starIndex = 2;
        else if (score >= level.score1Star) starIndex = 1;

        UpdateStars();
    }

    public void SetTarget(int target)
    {
        targetText.text = target.ToString();
    }

    public void SetRemaining(int remaining)
    {
        remainingText.text = remaining.ToString();
    }

    public void SetRemaining(string remaining)
    {
        remainingText.text = remaining;
    }

    public void SetLevelType(Level.LevelType type)
    {
        switch (type)
        {
            case Level.LevelType.MOVES:
                remainingSubtext.text = "moves remaining";
                targetSubtext.text = "target score";
                break;
            case Level.LevelType.OBSTACLE:
                remainingSubtext.text = "moves remaining";
                targetSubtext.text = "dishes remaining";
                break;
            case Level.LevelType.TIMER:
                remainingSubtext.text = "time remaining";
                targetSubtext.text = "target score";
                break;
        }
    }

    public void OnGameWin(int score)
    {
        GetComponent<Canvas>().sortingOrder = 3;
        GameOver.instance.ShowWin(score, starIndex);
    }
    public void OnGameLose()
    {
        GetComponent<Canvas>().sortingOrder = 3;
        isGameOver.instance.ShowLose();
    }
}
