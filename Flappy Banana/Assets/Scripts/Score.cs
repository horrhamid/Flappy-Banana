using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highScore;
    Text scoreText;

    // references
    public Text panelScore;
    public Text panelHighScore;
    public GameObject newImage;



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        //panelScore.text = score.ToString();

        highScore = PlayerPrefs.GetInt("highscore");
        panelHighScore.text = highScore.ToString();
    }

    public int ReturnGameScore()
    {
        return score;
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        if(score > highScore)
        {
            highScore = score;
            panelHighScore.text = score.ToString();
            PlayerPrefs.SetInt("highscore", highScore);
            newImage.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
