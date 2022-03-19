using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    bool endGameCheck = false;

    public string endScene1;
    public string endScene2;
    public string endScene3;

    public AudioClip winSFX;
    public AudioClip drawSFX;

    public float playTime = 200; //플레이타임

    public int winScore = 5; // 승리하는 득점 수

    void Start()
    {
        Invoke("endGame", playTime); //플레이 시간이 지나면 endGame함수 실행

        endScene1 = "EndScene1"; //플레이어1 승리장면
        endScene2 = "EndScene2"; //플레이어2 승리장면
        endScene3 = "EndScene3"; //무승부 장면
    }

    
    void Update()
    {
        if (GameObject.Find("ScoreText") != null)
        {
            win();
        }
        
    }

    void win()
    {
        
        if(GameObject.Find("ScoreText").GetComponent<Score>().scr1 >= winScore) // 승리점수를 채웠을 때
        {
            SceneManager.LoadScene(endScene1);
            GameObject.Find("EndSFX").GetComponent<AudioSource>().clip = winSFX;
            GameObject.Find("EndSFX").GetComponent<AudioSource>().Play();
        }
        else if (GameObject.Find("ScoreText").GetComponent<Score>().scr1 > GameObject.Find("ScoreText").GetComponent<Score>().scr2 && endGameCheck == true) //플레이 시간이 끝나고 플레이어1이 점수를 앞설 때
        {
            SceneManager.LoadScene(endScene1);
            GameObject.Find("EndSFX").GetComponent<AudioSource>().clip = winSFX;
            GameObject.Find("EndSFX").GetComponent<AudioSource>().Play();
        }
        else if (GameObject.Find("ScoreText").GetComponent<Score>().scr2 >= winScore)
        {
            SceneManager.LoadScene(endScene2);
            GameObject.Find("EndSFX").GetComponent<AudioSource>().clip = winSFX;
            GameObject.Find("EndSFX").GetComponent<AudioSource>().Play();
        }
        else if (GameObject.Find("ScoreText").GetComponent<Score>().scr2 > GameObject.Find("ScoreText").GetComponent<Score>().scr1 && endGameCheck == true)
        {
            SceneManager.LoadScene(endScene2);
            GameObject.Find("EndSFX").GetComponent<AudioSource>().clip = winSFX;
            GameObject.Find("EndSFX").GetComponent<AudioSource>().Play();
        }
        else if (GameObject.Find("ScoreText").GetComponent<Score>().scr2 == GameObject.Find("ScoreText").GetComponent<Score>().scr1 && endGameCheck == true) //플레이 시간이 끝나고 플레이어 점수가 같을 때
        {
            SceneManager.LoadScene(endScene3);
            GameObject.Find("EndSFX").GetComponent<AudioSource>().clip = drawSFX;
            GameObject.Find("EndSFX").GetComponent<AudioSource>().Play();
        }
        

    }

    void endGame()
    {
        endGameCheck = true; // 플레이 시간이 끝나면 동작
    }

}
