using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;

    private void Start()
    {
        highScoreText.text = "HIGH SCORE:" + PlayerPrefs.GetInt(UIManager.HIGH_SCORE_KEY, 0).ToString("###,000");
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
