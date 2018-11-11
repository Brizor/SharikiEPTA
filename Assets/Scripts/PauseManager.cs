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
    [SerializeField] GameObject modeText;

    private int bestScore;

    public void gameOver(int score)
    {
        scorePanel.SetActive(false);
        pausePanel.SetActive(true);
        modeText.SetActive(false);

        Time.timeScale = 0;
        if(bestScore < score)
        {
            bestScore = score;
            PlayerPrefs.SetInt("FirstPlace", bestScore);
            bestScoreText.text = "New Best " + bestScore.ToString();
        }
        else
        {
            scoreText.SetActive(true);
            bestScoreText.text = "Best " + bestScore.ToString();
            scoreText.GetComponent<Text>().text = "Score " + score.ToString();
        }
    }

    void Start () {
        modeText.SetActive(false);
        Time.timeScale = 0;
        bestScore = PlayerPrefs.GetInt("FirstPlace");
        bestScoreText.text = "Best " + bestScore.ToString();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            modeText.SetActive(true);
            scorePanel.SetActive(true);
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
}
