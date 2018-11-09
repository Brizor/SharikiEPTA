using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PauseManager : MonoBehaviour {
    [SerializeField] GameObject pausePanel;
    [SerializeField] Text bestScoreText;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject scorePanel;
    [SerializeField] Text modeText;

    private int bestScore;

    public void gameOver(int score)
    {
        scorePanel.SetActive(false);
        pausePanel.SetActive(true);

        Time.timeScale = 0;
        if(bestScore < score)
        {
            bestScoreText.text = "New Best " + bestScore.ToString();
            PlayerPrefs.SetInt("FirstPlace", bestScore);
        }
        else
        {
            scoreText.SetActive(true);
            bestScoreText.text = "Best " + bestScore.ToString();
            scoreText.GetComponent<Text>().text = "Score " + score.ToString();
        }
    }

    void Start () {
        Time.timeScale = 0;
        bestScore = PlayerPrefs.GetInt("FirstPlace");
        bestScoreText.text = "Best " + bestScore.ToString();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            scorePanel.SetActive(true);
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
}
