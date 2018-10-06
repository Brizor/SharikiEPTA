using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    [SerializeField] GameObject newGameButton;
    [SerializeField] GameObject bestButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject panel;
    [SerializeField] Text firstPlace;
    [SerializeField] Text secondPlace;
    [SerializeField] Text thirdPlace;
     private bool isPause;

    public void newGame()
    {
        sound();
        SceneManager.LoadScene("SampleScene");
    }

    private void sound()
    {
        AudioSource adioSource = GetComponent<AudioSource>();
        adioSource.PlayOneShot(adioSource.clip);
    }

    public void exit()
    {
        sound();
        Application.Quit();
    }

    public void best()
    {
        sound();
        if (!isPause)
        {
            newGameButton.SetActive(false);
            bestButton.SetActive(false);
            exitButton.SetActive(false);
            panel.SetActive(true);
            firstPlace.text = "1 place: " + PlayerPrefs.GetInt("FirstPlace");
            secondPlace.text = "2 place: " + PlayerPrefs.GetInt("SecondPlace");
            thirdPlace.text = "3 place: " + PlayerPrefs.GetInt("ThirdPlace");
            //заполнение
            isPause = !isPause;
        }
        else
        {
            panel.SetActive(false);
            newGameButton.SetActive(true);
            bestButton.SetActive(true);
            exitButton.SetActive(true);
            isPause = !isPause;
        }
        
    }

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        isPause = false;
        
    }


}
