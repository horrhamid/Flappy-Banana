using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMedal : MonoBehaviour
{
    // References

    public GameObject medal;
    public GameManager gameManager;
    void medalObjectShowsUp()
    {
        medal.SetActive(true);
        // drow the score

        gameManager.DrowScore();


    }
}
