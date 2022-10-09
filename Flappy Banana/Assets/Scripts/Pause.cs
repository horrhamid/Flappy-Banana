using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    Image img;

    // references
    public Sprite playerSprite;
    public Sprite pauseSprite;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnPauseGame()
    {
        if (GameManager.gameIsPaused == false)
        {
            Time.timeScale = 0;
            img.sprite = playerSprite;
            GameManager.gameIsPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            img.sprite = pauseSprite;
            GameManager.gameIsPaused = false;
        }

    }
}
