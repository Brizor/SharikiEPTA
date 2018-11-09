using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameplay", menuName = "GamePlay")]
public class GamePlay : ScriptableObject {
    //information about gameplay
    public float speed = 2.5f;
    public float maxSpeed = 3;
    public float minInterval = 3.9f;
    public float interval = 5;
    public float timeInterval = 5;//интервал до повышения сложности
    public float coefOfComplexity = 0.05f;

    public int countOfBubble = 3;
    public int intToModeUp = 5;
    public int typesOfBubbles = 2;
    public int minCountOfBables = 1;

}
