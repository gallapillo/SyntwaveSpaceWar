using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    bool isHidden = false;
    [SerializeField] GameObject playButton;

    void OnEnable()
    {
        EventManager.onStartGame += HidePanel;
    }


    void OnDisable()
    {
        EventManager.onStartGame -= HidePanel;
    }

    public void PlayGame()
    {
        EventManager.StartGame();
    }

    void HidePanel()
    {
        Debug.Log("IT WORKS");
        isHidden = !isHidden;
        if (isHidden)
        {
            playButton.SetActive(false);
        }
        else
        {
            playButton.SetActive(true);
        }
    }
}
