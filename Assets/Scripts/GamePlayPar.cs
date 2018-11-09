using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameplay", menuName = "GamePlay")]
public class GamePlay : ScriptableObject {
    //information about gameplay
    public int health;
    public float interval;// период вызова функции возможности изменения мода

    public float speedEasy;
    public int minCountOfBablesEasy;
    public int maxCountOfBubbleEasy;
    public int typesOfBubblesEasy;

    public float speedNormal;
    public int minCountOfBablesNormal;
    public int maxCountOfBubbleNormal;
    public int typesOfBubblesNormal;

    public float speedHard;
    public int minCountOfBablesHard;
    public int maxCountOfBubbleHard;
    public int typesOfBubblesHard;
}
