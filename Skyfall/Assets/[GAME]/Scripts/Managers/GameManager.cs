using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Observer design pattern ile kullan�lmak �zere seviyenin ba�ar�s�z olma durumunda �al��acak bir eylem (Action) tan�mland�
    [HideInInspector] public static Action OnLevelFail;
    //y�k�lan evlerin say�s�n� tutan de�i�ken
    [HideInInspector] public static int HouseDestroyCount;
    // oyunun ba�lam�� olup olmad���n� belirten flag
    [HideInInspector] public static bool isGameStarted;

    // oyun her ba�lad���nda de�erleri resetliyoruz.
    private void Start()
    {
        HouseDestroyCount = 0;
        isGameStarted = true;
    }
}
