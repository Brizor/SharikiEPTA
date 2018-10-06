using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PauseManager : MonoBehaviour {
    [SerializeField] GameObject panel;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject newScore;
    [SerializeField] GameObject pauseButton;
    [SerializeField] AudioClip buttonPresed;
    [SerializeField] AudioSource camera;
    [SerializeField] Text modeText;


    private int[] scores = new int[3];
    private bool pause;

    private void soundActive(AudioClip saund)
    {
        AudioSource adioSource = GetComponent<AudioSource>();
        adioSource.PlayOneShot(saund);
    }

    public void newGame()
    {
        soundActive(buttonPresed);
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void menu()
    {
        soundActive(buttonPresed);
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu"); ;
    }


    public void pauseActive()
    {
        soundActive(buttonPresed);
        if (!pause)
        {
            pause = !pause;
            Time.timeScale = 0;
            modeText.enabled = false;
            pauseButton.SetActive(false);
            panel.SetActive(true);
            exitButton.SetActive(true);
        }
        else
        {
            pause = !pause;
            Time.timeScale = 1;
            modeText.enabled = true;
            pauseButton.SetActive(true);
            exitButton.SetActive(false);
            panel.SetActive(false);
        }
    }

    public void gameOver(int score)
    {
        pauseButton.SetActive(false);
        camera.enabled = false;
        newScore.SetActive(true);
        

        if (score > scores[0])
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

        }

        PlayerPrefs.SetInt("FirstPlace", scores[0]);
        PlayerPrefs.SetInt("SecondPlace", scores[1]);
        PlayerPrefs.SetInt("ThirdPlace", scores[2]);

        Time.timeScale = 0;
        panel.SetActive(true);
        
    }

    // Use this for initialization
    void Start () {
        pause = false;
        scores[0] = PlayerPrefs.GetInt("FirstPlace");
        scores[1] = PlayerPrefs.GetInt("SecondPlace");
        scores[2] = PlayerPrefs.GetInt("ThirdPlace");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
