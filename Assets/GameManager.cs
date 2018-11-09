using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] AudioClip goodClip;
    [SerializeField] AudioClip badClip;
    [SerializeField] AudioClip shellClip;
    [SerializeField] AudioClip gameOverClip;
    [SerializeField] private Text healthText;
    [SerializeField] private Text scoreText;
    [SerializeField] GameObject MainCam;
    [SerializeField]  GameObject Line;
   // [SerializeField] GamePlay gamePlay;
    [SerializeField] SpriteRenderer valik;
    [SerializeField] BubbleManager bubbleManager;

    public int complexity;
    public float speed;
    public float maxSpeed;
    public float minInterval;
    public float interval;
    public float intToIncreaseComplexety;//интервал до повышения сложности
    public float coefOfComplexity;

    public float health;

    private int score;
    private float startTime;
    public int typeOfLine;
    private bool gameOver;

    private GamePlay gamePlay;

    public int tapsToCreate;

    private void soundActive(AudioClip saund)
    {
        AudioSource adioSource = GetComponent<AudioSource>();
        adioSource.PlayOneShot(saund);
    }

    public void goodReaction()
    {
        score++;
        scoreText.text =  score.ToString();
        soundActive(goodClip);
    }

    public void badReaction()
    {
        //soundActive(badClip);

       /* PauseManager pause = GetComponent<PauseManager>();
        pause.gameOver(score);*/
      
        
        if(health > 0 )
        {
            health--;
            if (health >= 1)
            {
                soundActive(badClip);

            }

            if (health <= 0)
            {
                
                PauseManager pause = GetComponent<PauseManager>();
                pause.gameOver(score);
                startParam();
            }
            //healthText.text = "HEALTH: " + health.ToString();
        }
    }

    public void shellReaction()
    {
        soundActive(shellClip);
    }

    public void destroyBubbleReaction(int type)
    { 
            if (type == typeOfLine)
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
        if(type != typeOfLine || type == 2 || type == 3)
        {
            badReaction();
        }
        else
        {
            goodReaction();
        }
        
    }

    /*public void upComplexity()
    {
        if(speed < maxSpeed)
        {
            speed += coefOfComplexity;
        }
 
        if(interval > minInterval)
        {
            interval -= coefOfComplexity;
        }
    }*/

    public void controlerOfMods()
    {
        int mod = Random.Range(0, 3);
        if(mod == 0)
        {
            speed = 2.5f;
            bubbleManager.typesOfBubbles = 2;
            bubbleManager.countOfBubble = 4;
            bubbleManager.minCountOfBables = 1;
            
        }
        if(mod == 1)
        {
            speed = 2.5f;
            bubbleManager.typesOfBubbles = 3;
            bubbleManager.countOfBubble = 5;
            bubbleManager.minCountOfBables = 3;
        }
        if(mod == 2)
        {
            speed = 2.3f;
            bubbleManager.typesOfBubbles = 4;
            bubbleManager.countOfBubble = 6;
            bubbleManager.minCountOfBables = 3;
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

            MainCam.GetComponent<Animator>().SetInteger("TypeOfLine", typeOfLine);
            Line.GetComponent<Animator>().SetInteger("TypeOfLine", typeOfLine);
            if (typeOfLine == 0)
            {
                valik.color = Color.blue;
            }
            else
            {
                valik.color = Color.red;
            }
        }
    }

    private void startParam()
    {
        health = 3;
        score = 0;
        tapsToCreate = 0;
        scoreText.text = score.ToString();

       // complexity = 0;
        speed = 2.5f;
        bubbleManager.typesOfBubbles = 2;
        bubbleManager.countOfBubble = 4;
        bubbleManager.minCountOfBables = 1;

        //speed = gamePlay.speed;
       // maxSpeed = gamePlay.maxSpeed;
       // minInterval = gamePlay.minInterval;
        interval = 40f;
        //intToIncreaseComplexety = gamePlay.timeInterval;
        //coefOfComplexity = gamePlay.coefOfComplexity;
        startTime = Time.time;


        typeOfLine = 0;
        MainCam.GetComponent<Animator>().SetInteger("TypeOfLine", typeOfLine);
        Line.GetComponent<Animator>().SetInteger("TypeOfLine", typeOfLine);

    }

    void Start () {
        
        gamePlay = ScriptableObject.CreateInstance<GamePlay>();
        Screen.orientation = ScreenOrientation.Portrait;
        //Time.timeScale = 1;
        health = 3;
        score = 0;
        tapsToCreate = 0;
        speed = 2.5f;
       

        

        //complexity = 0;

        //speed = gamePlay.speed;
        //maxSpeed = gamePlay.maxSpeed;
        //minInterval = gamePlay.minInterval;
        interval = 40f;
        //intToIncreaseComplexety = gamePlay.timeInterval;
       // coefOfComplexity = gamePlay.coefOfComplexity;

       // gameOver = false;

        typeOfLine = 0;
        //healthText.text = "HEALTH: " + health.ToString();
        scoreText.text = score.ToString();

        startTime = Time.time;
        Destroy(gamePlay);
	}

	void Update () {
        if(Time.time - startTime >= interval)
        {
            startTime = Time.time;
            controlerOfMods();
        }
	}
}
