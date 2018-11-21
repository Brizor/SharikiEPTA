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

    [SerializeField] private GameObject Mode;
    [SerializeField] private Text scoreText;
    [SerializeField] GameObject textOfModeAnim;

    [SerializeField] GamePlay gamePlay;

    public float speed;
    public float interval;
    public int tapsToCreate;

    public float health;
    private int score;
    private float startTime;
    public int typeOfLine;

    private int countOfEasyMod;
    private int countOfNormalMod;
    private int countOfHardMod;

    private float dopSpeed;
    private int countToDop;

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
        countToDop++;//experement
        if(countToDop >= 2)//experement
        {
            countToDop = 0;//experement
            if (dopSpeed <= 1f)//experement
            {
                dopSpeed += 0.1f;//experement
            }
        }//experement

        int mod = Random.Range(0, 3);
        if(mod == 0 && countOfEasyMod < 2)
        {
            countOfEasyMod++;
            countOfNormalMod = 0;
            countOfHardMod = 0;
                
          /*speed = 2.5f;
            bubbleManager.typesOfBubbles = 2;
            bubbleManager.minCountOfBubble = 1;
            bubbleManager.maxCountOfBables = 4;*/
            //easy mod
            speed = GamePlayParam.speedEasy + dopSpeed;//experement
            bubbleManager.typesOfBubbles = GamePlayParam.typesOfBubblesEasy;
            bubbleManager.maxCountOfBubble = GamePlayParam.maxCountOfBubbleEasy;
            bubbleManager.minCountOfBables = GamePlayParam.minCountOfBablesEasy;
            Mode.GetComponent<Text>().text = "EASY";
            Mode.GetComponent<Text>().color = Color.green;
            textOfModeAnim.GetComponent<Text>().text = "EASY";
            textOfModeAnim.GetComponent<Text>().color = Color.green;
            textOfModeAnim.GetComponent<Animation>().Play();
        }
        if(mod == 1 && countOfNormalMod < 2)
        {
            countOfEasyMod = 0;
            countOfNormalMod++;
            countOfHardMod = 0;
            /*speed = 2.5f;
              bubbleManager.typesOfBubbles = 3;
              bubbleManager.minCountOfBubble = 3;
              bubbleManager.maxCountOfBables = 5;*/
            //normal mod
            speed = GamePlayParam.speedNormal + dopSpeed;//experement
            bubbleManager.typesOfBubbles = GamePlayParam.typesOfBubblesNormal;
            bubbleManager.maxCountOfBubble = GamePlayParam.maxCountOfBubbleNormal;
            bubbleManager.minCountOfBables = GamePlayParam.minCountOfBablesNormal;
            Mode.GetComponent<Text>().text = "NORMAL";
            Mode.GetComponent<Text>().color = Color.yellow;
            textOfModeAnim.GetComponent<Text>().text = "NORMAL";
            textOfModeAnim.GetComponent<Text>().color = Color.yellow;
            textOfModeAnim.GetComponent<Animation>().Play();
        }
        if(mod == 2 && countOfHardMod < 2)
        {
            countOfEasyMod = 0;
            countOfNormalMod = 0;
            countOfHardMod++;
            /*speed = 2.3f;
              bubbleManager.typesOfBubbles = 4;
              bubbleManager.minCountOfBables = 3;
              bubbleManager.maxCountOfBubble = 6;*/
            //toby pizda mod
            speed = GamePlayParam.speedHard + dopSpeed;//experement
            bubbleManager.typesOfBubbles = GamePlayParam.typesOfBubblesHard;
            bubbleManager.minCountOfBables = GamePlayParam.minCountOfBablesHard;
            bubbleManager.maxCountOfBubble = GamePlayParam.maxCountOfBubbleHard;
            Mode.GetComponent<Text>().text = "HARD";
            Mode.GetComponent<Text>().color = Color.red;
            textOfModeAnim.GetComponent<Text>().text = "HARD";
            textOfModeAnim.GetComponent<Text>().color = Color.red;
            textOfModeAnim.GetComponent<Animation>().Play();
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

        dopSpeed = 0f;//experement
        countToDop = 0;//experement

        health = GamePlayParam.health;
        speed = GamePlayParam.speedEasy + dopSpeed;//experement
        interval = GamePlayParam.interval;
        bubbleManager.typesOfBubbles = GamePlayParam.typesOfBubblesEasy;
        bubbleManager.maxCountOfBubble = GamePlayParam.maxCountOfBubbleEasy;
        bubbleManager.minCountOfBables = GamePlayParam.minCountOfBablesEasy;
        countOfEasyMod = 1;
        countOfNormalMod = 0;
        countOfHardMod = 0;

        bubbleManager.gameObject.SetActive(false);
        Mode.GetComponent<Text>().text = "EASY";
        Mode.GetComponent<Text>().color = Color.green;
        textOfModeAnim.GetComponent<Text>().text = "EASY";
        textOfModeAnim.GetComponent<Text>().color = Color.green;
        textOfModeAnim.GetComponent<Animation>().Play();
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

        dopSpeed = 0f;//experement
        countToDop = 0;//experement

        /*health = 3;
        speed = 2.5f;
        interval = 40f;*/
        bubbleManager.gameObject.SetActive(false);
        Mode.GetComponent<Text>().text = "EASY";
        Mode.GetComponent<Text>().color = Color.green;
        textOfModeAnim.GetComponent<Text>().text = "EASY";
        textOfModeAnim.GetComponent<Text>().color = Color.green;
        textOfModeAnim.GetComponent<Animation>().Play();
        

        health = GamePlayParam.health;
        speed = GamePlayParam.speedEasy + dopSpeed;//experement
        interval = GamePlayParam.interval;
        countOfEasyMod = 1;
        countOfNormalMod = 0;
        countOfHardMod = 0;
    }

	void Update () {
        if(Time.time - startTime >= interval && tapsToCreate <= 0 && Time.timeScale != 0)
        {
            bubbleManager.gameObject.SetActive(false);
            startTime = Time.time;
            controlerOfMods();
        }
	}
}
