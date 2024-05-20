using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Observer design pattern ile kullanýlmak üzere seviyenin baþarýsýz olma durumunda çalýþacak bir eylem (Action) tanýmlandý
    [HideInInspector] public static Action OnLevelFail;
    //yýkýlan evlerin sayýsýný tutan deðiþken
    [HideInInspector] public static int HouseDestroyCount;
    // oyunun baþlamýþ olup olmadýðýný belirten flag
    [HideInInspector] public static bool isGameStarted;

    // oyun her baþladýðýnda deðerleri resetliyoruz.
    private void Start()
    {
        HouseDestroyCount = 0;
        isGameStarted = true;
    }
}
