using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] AudioClip goodClip;
    [SerializeField] AudioClip badClip;
    [SerializeField] AudioClip shellClip;
    [SerializeField] AudioClip gameOverClip;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject badReactionAnim;
    [SerializeField] private Text healthText;
    [SerializeField] private Text scoreText;
    [SerializeField]  GameObject anim1;
    [SerializeField] GamePlay gamePlay;

    public float speed;
    public float maxSpeed;
    public float minInterval;
    public float interval;
    public float timeInterval;//интервал до повышения сложности
    public float coefOfComplexity;

    private float health;

    private int score;
    private float startTime;
    public int typeOfLine;
    private bool gameOver;

    private void soundActive(AudioClip saund)
    {
        AudioSource adioSource = GetComponent<AudioSource>();
        adioSource.PlayOneShot(saund);
    }

    public void goodReaction()
    {
        score++;
        scoreText.text = "SCORE: " + score.ToString();
        soundActive(goodClip);
    }

    public void badReaction()
    {
        if (health > 0 )
        {
            health--;
            if (health >= 1)
            {
                badReactionAnim.GetComponent<Animation>().Play();
                soundActive(badClip);

            }

            if (health <= 0 && !gameOver)
            {
                soundActive(gameOverClip);
                gameOver = true;
                PauseManager pause = GetComponent<PauseManager>();
                pause.gameOver(score);
            }
            healthText.text = "HEALTH: " + health.ToString();
        }
    }

    public void shellReaction()
    {
        soundActive(shellClip);
    }

    public void destroyBubbleReaction(int type)
    { 
            if (type != typeOfLine)
            {
                badReaction();
            }
            else
            {
                goodReaction();
            }    
    }

    public void bubbleCollision(int type)
    {
        if(type == typeOfLine || type == 2)
        {
            badReaction();
        }
        else
        {
            goodReaction();
        }
        
    }

    private void upComplexity()
    {
        if(speed < maxSpeed)
        {
            speed += coefOfComplexity;
        }
 
        if(interval > minInterval)
        {
            interval -= coefOfComplexity;
        }
    }

    

    public void changeColor()
    {
         int rnd = Random.Range(0, 2);
        if (typeOfLine == rnd)
        {
            return;
        }
        else
        {
            typeOfLine = rnd;

            anim1.GetComponent<Animator>().SetInteger("TypeOfLine", typeOfLine);
        }
    }

	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
        Time.timeScale = 1;
        health = 8;
        score = 0;
        /* speed = 2;
         minInterval = 3.9f;
         timeInterval = 5;
         interval = 5;
         maxSpeed = 3f;
         coefOfComplexity = 0.05f;*/
        speed = gamePlay.speed;
        maxSpeed = gamePlay.maxSpeed;
        minInterval = gamePlay.minInterval;
        interval = gamePlay.interval;
        timeInterval = gamePlay.timeInterval;
        coefOfComplexity = gamePlay.coefOfComplexity;

        gameOver = false;

        typeOfLine = 1;
        healthText.text = "HEALTH: " + health.ToString();
        scoreText.text = "SCORE: " + score.ToString();

        startTime = Time.time;
	}

	void Update () {
        if(Time.time - startTime >= timeInterval)
        {
            startTime = Time.time;
            upComplexity();
        }
	}
}
