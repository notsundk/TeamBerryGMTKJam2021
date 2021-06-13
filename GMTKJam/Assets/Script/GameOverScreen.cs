using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public ScoreTracker sc;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI Score;

    private void Start()
    {
        HighScore.text = sc.HighScore.ToString();
        Score.text = sc.CurrentScore.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Stage");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
