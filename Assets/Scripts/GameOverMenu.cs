using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "HIGH SCORE:" + PlayerPrefs.GetInt(UIManager.HIGH_SCORE_KEY, 0).ToString("###,000");
        scoreText.text = "SCORE:" + UIManager.instance.GetScore().ToString("###,000");
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
