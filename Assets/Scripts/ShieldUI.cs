using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUI : MonoBehaviour
{
    [SerializeField] RectTransform barRectTransform;
    [SerializeField] Sheild sheild;
    float maxWidth;

    void Awake()
    {
        maxWidth = barRectTransform.rect.width;    
    }

    void OnEnable()
    {
        EventManager.onTakeDamage += UpdateShieldDisplay;    
    }

    void OnDisable()
    {
        EventManager.onTakeDamage -= UpdateShieldDisplay;
    }

    void UpdateShieldDisplay(float rectangle)
    {
        Debug.Log("DAMGE IS : " + sheild.getHealth() / 10);
        barRectTransform.sizeDelta = new Vector2(maxWidth * (float)(sheild.getHealth() / 10f), 10f);
    }

}
