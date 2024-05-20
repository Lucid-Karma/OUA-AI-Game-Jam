using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static Action OnLevelFail;
    [HideInInspector] public static Action OnLevelRestart;

    [HideInInspector] public static int HouseDestroyCount;

    [HideInInspector] public static bool isGameStarted;

    private void Start()
    {
        HouseDestroyCount = 0;
        isGameStarted = true;
    }
}
