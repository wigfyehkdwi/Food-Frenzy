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

    public Image[] stars;

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
}
