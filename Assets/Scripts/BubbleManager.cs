using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BubbleManager : MonoBehaviour {

    [SerializeField] GameObject prefabBubble;
    [SerializeField] GameObject badBubblePrefab;
    [SerializeField] GameObject shellPrefab;
    [SerializeField] GameObject dualPref;
    [SerializeField] GameManager gameManager;
    [SerializeField] GamePlay gamePlay;
    private GameObject newBubble;
 
    public Transform[] positions1 = new Transform[11];
    public Transform[] positions2 = new Transform[11];
    //string[] modes = new string []{"EASY MODE: ", "NORMAL MODE: ", "HARD MODE: " };

    public int minCountOfBables;
    private int howMuch;
    public int maxCountOfBubble;
    public int typesOfBubbles;

    private float intervalToCreateDop;
    private bool canCreateDop = false;
    
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

      private void createBubble(int quantity, Transform[] positions)
      {
        int were;
        int what;
        int range = 11;
        int[] MasOfVar = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

         for(int i = 0; i < quantity;i++)
         {
            
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

      private void startParam()
      {
        /* typesOfBubbles = 2;
         minCountOfBubble = 1;
         maxCountOfBables = 4;*/
        canCreateDop = false;
        typesOfBubbles = GamePlayParam.typesOfBubblesEasy;
        maxCountOfBubble = GamePlayParam.maxCountOfBubbleEasy;
        minCountOfBables = GamePlayParam.minCountOfBablesEasy;
      }

     void Start(){
        /*typesOfBubbles = 2;
        minCountOfBubble = 1;
        maxCountOfBables = 4;*/

        canCreateDop = false;
        typesOfBubbles = GamePlayParam.typesOfBubblesEasy;
        maxCountOfBubble = GamePlayParam.maxCountOfBubbleEasy;
        minCountOfBables = GamePlayParam.minCountOfBablesEasy;
     }

    void Update() {
       if (gameManager.tapsToCreate <= 0 && Time.timeScale != 0)
       {
            canCreateDop = true;
            intervalToCreateDop = Time.time;
         gameManager.changeColor();
         howMuch = Random.Range(minCountOfBables, maxCountOfBubble);
         gameManager.tapsToCreate += howMuch;//*2;
         createBubble(howMuch , positions1);
         //createBubble(howMuch, positions2);
       }
       if(Time.time - intervalToCreateDop >= 3f && Time.timeScale != 0 && canCreateDop)
        {
            canCreateDop = false;
            intervalToCreateDop = Time.time;
            howMuch = Random.Range(minCountOfBables, maxCountOfBubble);
            gameManager.tapsToCreate += howMuch;
            createBubble(howMuch, positions1);
        }
    } 
} 
