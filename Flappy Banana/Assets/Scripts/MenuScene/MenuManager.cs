using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // references
    public Animator blackFadeAnim;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayBtnPressed()
    {
        AudioManager.audiomanager.Play("transition");

        // SceneManager.LoadScene("Game");
        blackFadeAnim.SetTrigger("FadeIn");

    }

    public void OnRateBtnPressed()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.BananaGameMakers.FlappyBird");
#endif 
    }
}
