using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //references
    public GameObject gameOverCanvas;
    public GameObject score;
    public GameObject getReadyImg;
    public GameObject pauseBtn;
    public Animator blackFadeAnim;
    public Text panelScore;

    //Game States
    public static bool gameOver;
    public static bool gameHasStarted;
    public static bool gameIsPaused;
    public static int gameScore;

    int drowScore;
    


    public static Vector2 bottomLeft;

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameHasStarted = false;
        gameIsPaused = false;
    }

    public void GameHasStarted()
    {
        gameHasStarted = true;
        score.SetActive(true);
        getReadyImg.SetActive(false);
        pauseBtn.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverCanvas.SetActive(true);
        AudioManager.audiomanager.Play("die");

        // get Final Score
        gameScore = score.GetComponent<Score>().ReturnGameScore();

        score.SetActive(false);
    }

    public void DrowScore()
    {
        if(drowScore <= gameScore)
        {
            panelScore.text = drowScore.ToString();
            drowScore++;
            Invoke("DrowScore", 0.05f);
        }
    }

    

    public void OnMenuBtnPressed()
    {
        AudioManager.audiomanager.Play("transition");

        //SceneManager.LoadScene("Menu");
        blackFadeAnim.SetTrigger("FadeIn");
    }
    public void OnOkBtnPressed()
    {
        AudioManager.audiomanager.Play("transition");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
