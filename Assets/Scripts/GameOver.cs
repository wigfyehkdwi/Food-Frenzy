using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject screenParent;
    public GameObject scoreParent;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI scoreText;
    public Image[] stars;
    private Animator animator;

    public static GameOver instance;

    // Start is called before the first frame update
    void Start()
    {
        screenParent.SetActive(false);

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = true;
        }

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void ShowLose()
    {
        screenParent.SetActive(true);
        scoreParent.SetActive(false);
        loseText.enabled = true;

        if (animator) animator.Play("GameOverDisplay");
    }

    public void ShowWin(int score, int starCount)
    {
        screenParent.SetActive(true);
        scoreParent.SetActive(true);
        loseText.enabled = false;
        scoreText.text = score.ToString();
        scoreText.enabled = false;
        if (animator) animator.Play("GameOverShow");

        StartCoroutine(ShowWinCoroutine(starCount));
    }

    private IEnumerator ShowWinCoroutine(int starCount)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            stars[i].enabled = true;
            if (i > 0) stars[i - 1].enabled = false;
        }

        scoreText.enabled = true;
    }

    public void OnReplayClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnDoneClicked()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
