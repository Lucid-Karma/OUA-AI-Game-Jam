using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    // Tüm sýnýflar tarafýndan eriþilebilecek statik bir saðlýk deðiþkeni.
    public static int health;

    private void Start()
    {
        health = 3;
    }
}
