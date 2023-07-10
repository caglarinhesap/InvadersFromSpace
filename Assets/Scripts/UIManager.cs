using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI highScoreText;
    private int highScore;
    public TextMeshProUGUI coinsText;
    private int coins;
    public TextMeshProUGUI waveText;
    private int wave;
    public Image[] lifeSprites;
    public Image healthBar;
    public Sprite[] healthBars;
    private Color32 active = new Color(1, 1, 1, 1);
    private Color32 inactive = new Color(1, 1, 1, 0.25f);

    public const string HIGH_SCORE_KEY = "HighScore";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetScore()
    {
        return instance.score;
    }

    private void Start()
    {
        instance.highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        instance.highScoreText.text = instance.highScore.ToString("###,000");
    }

    public static void UpdateLives(int l)
    {
        //TODO: if l == 0, player dead. Go to game over screen. and set highscore on there
        if (l == 0)
        {
            SaveHighScore();
            SceneManager.LoadScene(2);
        }

        foreach (Image i in instance.lifeSprites)
        {
            i.color = instance.inactive;
        }
        for (int i = 0; i < l; i++)
        {
            instance.lifeSprites[i].color = instance.active;
        }
    }
    
    public static void UpdateHealthBar(int h)
    {
        instance.healthBar.sprite = instance.healthBars[h];
    }

    public static void UpdateScore(int s)
    {
        instance.score += s;
        instance.scoreText.text = instance.score.ToString("###,000");
        UpdateHighScore();
    }

    public static void UpdateHighScore()
    {
        if (instance.score > instance.highScore)
        {
            instance.highScore = instance.score;
            instance.highScoreText.text = instance.highScore.ToString("###,000");
        }
    }

    public static void SaveHighScore()
    {
        if (instance.score > instance.highScore)
        {
            instance.highScore = instance.score;
            instance.highScoreText.text = instance.highScore.ToString("###,000");
        }
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, instance.highScore);
    }

    public static void UpdateWave()
    {
        instance.wave++;
        instance.waveText.text = instance.wave.ToString();
    }

    public static void UpdateCoins()
    {
        instance.coinsText.text = Inventory.currentCoins.ToString();
    }

}
