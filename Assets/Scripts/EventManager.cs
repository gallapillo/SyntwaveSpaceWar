using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;

    public delegate void TakeDamageDelegate(float amt);
    public static TakeDamageDelegate onTakeDamage;

    public static void StartGame()
    {
        if (onStartGame != null)
            onStartGame();
    }


    public static void TakeDamage(float dmg)
    {
        Debug.Log("TAKE DAMAGE: " + dmg);
        if (onTakeDamage != null)
            onTakeDamage(dmg);
    }
}
