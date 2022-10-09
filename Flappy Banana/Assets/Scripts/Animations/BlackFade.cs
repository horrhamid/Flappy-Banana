using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BlackFade : MonoBehaviour
{
    void OnBlackFadeFinishes()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            SceneManager.LoadScene("Game");
        }
        else if(SceneManager.GetActiveScene().name == "Game")
        {
            SceneManager.LoadScene("Menu");
        }

    }
}
