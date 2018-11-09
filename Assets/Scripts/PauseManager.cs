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
   // [SerializeField] AudioSource camera;
    [SerializeField] Text modeText;


   // private int[] scores = new int[3];
  //  private bool pause;
    private int bestScore;


    public void gameOver(int score)
    {
        scorePanel.SetActive(false);
        // active text to start;
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        if(bestScore < score)
        {
            bestScoreText.text = "New Best " + bestScore.ToString();
            PlayerPrefs.SetInt("FirstPlace", bestScore);
        }
        {
            scoreText.SetActive(true);
            bestScoreText.text = "Best " + bestScore.ToString();
            scoreText.GetComponent<Text>().text = "Score " + score.ToString();
        }
        /*if (score > scores[0])
        {
            newScore.GetComponentInChildren<Text>().text = "New best score :" + score;
        }
        else
        {
            newScore.GetComponentInChildren<Text>().text = "Your score : " + score;
        }
        int temp;

        for(int i = 0;i < scores.Length; i++)//хуйня
        {
            if(score > scores[i] )
            {
                for(int j = scores.Length - 1; j != i; j--)
                {
                    temp = scores[j];
                    scores[j] = scores[j - 1];
                    scores[j - 1] = temp;
                    
                }
                scores[i] = score;
                break;
            }

        }*/


        /*PlayerPrefs.SetInt("SecondPlace", scores[1]);
        PlayerPrefs.SetInt("ThirdPlace", scores[2]);*/

        
        //panel.SetActive(true);
        
    }

    // Use this for initialization
    void Start () {
        //bestScoreActive;
        Time.timeScale = 0;
        bestScore = PlayerPrefs.GetInt("FirstPlace");
        bestScoreText.text = "Best " + bestScore.ToString();
        /*scores[0] = PlayerPrefs.GetInt("FirstPlace");
        scores[1] = PlayerPrefs.GetInt("SecondPlace");
        scores[2] = PlayerPrefs.GetInt("ThirdPlace");*/
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
