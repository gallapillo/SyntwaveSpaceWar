using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheild : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int curHealth;
    [SerializeField] int renerateAmount = 1;
    [SerializeField] float renerationRaite = 2f;
    

    void Start()
    {
        curHealth = maxHealth;

        InvokeRepeating("Regenerate", renerationRaite, renerationRaite);
    }

    void Regenerate()
    {
        if (curHealth < maxHealth)
            curHealth += renerateAmount;

        if (curHealth > maxHealth)
            curHealth = maxHealth;
    }

    public void TakeDamage(int dmg = 1)
    {
        curHealth -= dmg;

        if (curHealth < 0)
            curHealth = 0;

        EventManager.TakeDamage(curHealth / (float)maxHealth);
        if (curHealth < 1)
        {
            GetComponent<Explosion>().BlowUp();
            // renove a life fronm the life counter
            Debug.Log("DEATH");
        }
            
    }

    public int getHealth()
    {
        return curHealth;
    }
}
