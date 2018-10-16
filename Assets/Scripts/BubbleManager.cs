﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BubbleManager : MonoBehaviour {

    [SerializeField] GameObject prefabBubble;
    [SerializeField] GameObject badBubblePrefab;
    [SerializeField] GameObject shellPrefab;
    [SerializeField] GameObject dualPref;
    [SerializeField] GameManager gameManager;
    [SerializeField] Text textOfMode;
    [SerializeField] GamePlay gamePlay;
    private GameObject newBubble;
 
    public Transform[] positions = new Transform[12];
    string[] modes = new string []{"EASY MODE: ", "NORMAL MODE: ", "HARD MODE: " };

    public int minCountOfBables;
    private int howMuch;
    private float intervalToCreateBubble;
    public int intToModeUp;
    private int mode;
    public int countOfBubble;
    public int typesOfBubbles;
    

  
      private int[] cutMas(int[] Mas, int avoid)
      {
         int[] MasOfVar = new int[Mas.Length - 1];
         int j = 0;

          for(int i = 0; i < Mas.Length; i++)
          {
             if(Mas[i] != avoid)
             {
                MasOfVar[j] = Mas[i];
                j++;
             }
          }
         return MasOfVar;
      }

      private void createBubble(int quantity)
      {
        int were;
        int what;
        int range = 12;
         int[] MasOfVar = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};

         for(int i = 0; i < quantity;i++)
         {
            gameManager.changeColor();
            newBubble = null;
            
            were = Random.Range(0, range);

            what = Random.Range(0, typesOfBubbles);
            
            if (what == 0)
            {
                newBubble = Instantiate(prefabBubble, positions[MasOfVar[were]].position, transform.rotation);
                MasOfVar = cutMas(MasOfVar, MasOfVar[were]);
                newBubble.GetComponent<BubbleMove>().gameManager = this.gameManager;
                newBubble.GetComponent<ActionsWithBubbles>().gameManager = this.gameManager;
                newBubble.GetComponent<ActionsWithBubbles>().type = what;
                range--;
            }

            if (what == 1)
            {
                newBubble = Instantiate(badBubblePrefab, positions[MasOfVar[were]].position, transform.rotation);
                MasOfVar = cutMas(MasOfVar, MasOfVar[were]);
                newBubble.GetComponent<BubbleMove>().gameManager = this.gameManager;
                newBubble.GetComponent<ActionsWithBubbles>().gameManager = this.gameManager;
                newBubble.GetComponent<ActionsWithBubbles>().type = what;
                range--;
            }
            if(what == 2)
            {
                newBubble = Instantiate(shellPrefab, positions[MasOfVar[were]].position, transform.rotation);
                MasOfVar = cutMas(MasOfVar, MasOfVar[were]);
                newBubble.GetComponent<actionWithShell>().gameManager = this.gameManager;
                range--;
            }
            if(what == 3)
            {
                newBubble = Instantiate(dualPref, positions[MasOfVar[were]].position, transform.rotation);
                MasOfVar = cutMas(MasOfVar, MasOfVar[were]);
                newBubble.GetComponent<DualBubbleAction>().gameManager = this.gameManager;
                range--;
            }
         }
      }

       void Start() {
           mode = 1;
        
        upComplexity(mode);
        /*countOfBubble = 3;
        intToModeUp = 5;
        typesOfBubbles = 2;
        minCountOfBables = 1;*/

        countOfBubble = gamePlay.countOfBubble;
        intToModeUp = gamePlay.intToModeUp;
        typesOfBubbles = gamePlay.typesOfBubbles;
        minCountOfBables = gamePlay.minCountOfBables;

        intervalToCreateBubble = gameManager.interval;


          /* positions[0] = new Vector3(-2.15f, -5f, 0f);
           positions[1] = new Vector3(-0.85f, -5f, 0f);
           positions[2] = new Vector3(0.85f, -5f, 0f);
           positions[3] = new Vector3(2.15f, -5f, 0f);
           positions[4] = new Vector3(-2.15f, -6f, 0f);
           positions[5] = new Vector3(-0.85f, -6f, 0f);
           positions[6] = new Vector3(0.85f, -6f, 0f);
           positions[7] = new Vector3(2.15f, -6f, 0f);*/
       }

       private void upComplexity(int complexity)
       {
         if(complexity == 7)
         {
            gameManager.upComplexity();
            countOfBubble++;
         }
        if (complexity == 14)
        {
            gameManager.upComplexity();
            typesOfBubbles++;
        }
        if (complexity == 21)
        {
            gameManager.upComplexity();
            countOfBubble++;
            minCountOfBables++;
        }
        if (complexity == 28)
        {
            gameManager.upComplexity();
            countOfBubble++;
        }

        if (complexity == 35)
        {
            gameManager.upComplexity();
            countOfBubble++;
            typesOfBubbles++;
        }

        if(complexity == 42)
        {
            gameManager.upComplexity();
            countOfBubble++;
        }

        if(complexity == 49)
        {
            gameManager.upComplexity();
            countOfBubble++;
        }

        if(complexity == 56)
        {
            gameManager.upComplexity();
            minCountOfBables++;
        }

        /*if (complexity <= 5)
         {
           textOfMode.text = modes[0] + complexity;
           textOfMode.color = new Color(0,186,255);
         }
         if(complexity > 5 && complexity <= 10)
         {
            textOfMode.text = modes[1] + (complexity - 5);
            textOfMode.color = new Color(255, 233, 0);
         }
         if (complexity > 10)
         {

            textOfMode.text = modes[2] + (complexity - 10);
            textOfMode.color = new Color(255, 0, 28);
         }
         textOfMode.GetComponent<Animation>().Play();*/

        gameManager.complexity++;
       }

       void Update() {
          intervalToCreateBubble -= Time.deltaTime;
          if (intervalToCreateBubble <= 0)
          {
            
            //intToModeUp--;
            intervalToCreateBubble = gameManager.interval;
            upComplexity(gameManager.complexity);

            howMuch = Random.Range(minCountOfBables, countOfBubble);
            createBubble(howMuch);

            /*if(intToModeUp <= 0)
            {
                mode++;
                intToModeUp = 5;
                upComplexity(mode);
            }*/
          }
       } 
    } 
