using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [System.Serializable]
    public struct ButtonPlayerPrefs
    {
        public GameObject gameObject;
        public string playerPrefKey;
    }

    public ButtonPlayerPrefs[] buttons;

    public void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int score = PlayerPrefs.GetInt(buttons[i].playerPrefKey, 0);

            for (int j = 1; j <= 3; j++)
            {
                Transform star = buttons[i].gameObject.transform.Find("star" + j);
                star.gameObject.SetActive(j <= score);
            }
        }
    }

    public void OnButtonPress(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
