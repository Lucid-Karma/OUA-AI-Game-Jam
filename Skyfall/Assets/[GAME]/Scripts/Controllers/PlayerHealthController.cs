using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    // T�m s�n�flar taraf�ndan eri�ilebilecek statik bir sa�l�k de�i�keni.
    public static int health;

    private void Start()
    {
        health = 3;
    }
}
