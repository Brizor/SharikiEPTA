using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] AudioClip goodClip;
    [SerializeField] AudioClip badClip;
    [SerializeField] AudioClip shellClip;
    [SerializeField] AudioClip gameOverClip;

    [SerializeField] GameObject MainCam;
    [SerializeField]  GameObject Line;
    [SerializeField] SpriteRenderer valik;
    [SerializeField] BubbleManager bubbleManager;

    [SerializeField] private Text healthText;
    [SerializeField] private Text scoreText;

    [SerializeField] GamePlay gamePlay;

    public float speed;
    public float interval;
    public int tapsToCreate;

    public float health;
    private int score;
    private float startTime;
    public int typeOfLine;

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

    public void controlerOfMods()
    {
        int mod = Random.Range(0, 3);
        if(mod == 0)
        {
          /*speed = 2.5f;
            bubbleManager.typesOfBubbles = 2;
            bubbleManager.minCountOfBubble = 1;
            bubbleManager.maxCountOfBables = 4;*/
            //easy mod
            speed = gamePlay.speedEasy;
            bubbleManager.typesOfBubbles = gamePlay.typesOfBubblesEasy;
            bubbleManager.maxCountOfBubble = gamePlay.maxCountOfBubbleEasy;
            bubbleManager.minCountOfBables = gamePlay.minCountOfBablesEasy;
        }
        if(mod == 1)
        {
          /*speed = 2.5f;
            bubbleManager.typesOfBubbles = 3;
            bubbleManager.minCountOfBubble = 3;
            bubbleManager.maxCountOfBables = 5;*/
            //normal mod
            speed = gamePlay.speedNormal;
            bubbleManager.typesOfBubbles = gamePlay.typesOfBubblesNormal;
            bubbleManager.maxCountOfBubble = gamePlay.maxCountOfBubbleNormal;
            bubbleManager.minCountOfBables = gamePlay.minCountOfBablesNormal;
        }
        if(mod == 2)
        {
          /*speed = 2.3f;
            bubbleManager.typesOfBubbles = 4;
            bubbleManager.minCountOfBables = 3;
            bubbleManager.maxCountOfBubble = 6;*/
            //toby pizda mod
            speed = gamePlay.speedHard;
            bubbleManager.typesOfBubbles = gamePlay.typesOfBubblesHard;
            bubbleManager.minCountOfBables = gamePlay.minCountOfBablesHard;
            bubbleManager.maxCountOfBubble = gamePlay.maxCountOfBubbleHard;
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
        score = 0;
        scoreText.text = score.ToString();
        tapsToCreate = 0;
        startTime = Time.time;

        /*health = 3;
        speed = 2.5f;
        bubbleManager.typesOfBubbles = 2;
        bubbleManager.maxCountOfBubble = 4;
        bubbleManager.minCountOfBables = 1;
        interval = 40f;*/

        health = gamePlay.health;
        speed = gamePlay.speedEasy;
        interval = gamePlay.interval;
        bubbleManager.typesOfBubbles = gamePlay.typesOfBubblesEasy;
        bubbleManager.maxCountOfBubble = gamePlay.maxCountOfBubbleEasy;
        bubbleManager.minCountOfBables = gamePlay.minCountOfBablesEasy;

        typeOfLine = 0;
        MainCam.GetComponent<Animator>().SetInteger("TypeOfLine", typeOfLine);
        Line.GetComponent<Animator>().SetInteger("TypeOfLine", typeOfLine);
    }

    void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
        score = 0;
        scoreText.text = score.ToString();
        tapsToCreate = 0;
        typeOfLine = 0;
        startTime = Time.time;

        /*health = 3;
        speed = 2.5f;
        interval = 40f;*/

        health = gamePlay.health;
        speed = gamePlay.speedEasy;
        interval = gamePlay.interval;
	}

	void Update () {
        if(Time.time - startTime >= interval)
        {
            startTime = Time.time;
            controlerOfMods();
        }
	}
}
