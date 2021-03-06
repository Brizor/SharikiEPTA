﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePlayParam {

    static public int health = 3;
    static public float interval = 30f;// период вызова функции возможности изменения мода

    static public float speedEasy = 2.5f;
    static public int minCountOfBablesEasy = 1;
    static public int maxCountOfBubbleEasy = 4;
    static public int typesOfBubblesEasy = 2;

    static public float speedNormal = 2.5f;
    static public int minCountOfBablesNormal = 3;
    static public int maxCountOfBubbleNormal = 5;
    static public int typesOfBubblesNormal = 3;

    static public float speedHard = 2.3f;
    static public int minCountOfBablesHard = 4;
    static public int maxCountOfBubbleHard = 6;
    static public int typesOfBubblesHard = 4;
}
