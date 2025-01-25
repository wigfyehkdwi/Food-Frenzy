using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Image starsImage;
    public TMP_Text scoreText;
    public TMP_Text loseText;

    public Button replayButton;
    public Button doneButton;

    public static GameOver instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance) return;
        instance = this;
        gameObject.SetActive(false);
        starsImage.enabled = false;
        scoreText.enabled = false;
        loseText.enabled = false;
        replayButton.GameObject.SetActive(false);
        doneButton.gameObject.SetActive(false);
        replayButton.onClick.AddListener(OnReplayClicked);
        replayButton.onClick.AddListener(OnDoneClicked);
    }

    // Update is called once per frame
    public void ShowLose()
    {
        gameObject.SetActive(true);
        replayButton.gameObject.SetActive(true);
        doneButton.gameObject.SetActive(true);
        loseText.enabled = true;
    }

    public void ShowWin(int score, int starCount)
    {
        gameObject.SetActive(true);
        starsImage.enabled = true;
        scoreText.text = score.ToString();

        StartCoroutine(ShowWinCoroutine(starCount));
    }

    private IEnumerator ShowWinCoroutine(int starCount)
    {
        for (int i = 0; i <= starCount; i++)
        {
            yield return new WaitForSeconds(0.5f);
            starsImage.sprite = HUD.instance.stars[i];
        }

        scoreText.enabled = true;
        replayButton.gameObject.SetActive(true);
        doneButton.gameObject.SetActive(true);
    }

    public void OnReplayClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnDoneClicked()
    { 
    }
}
