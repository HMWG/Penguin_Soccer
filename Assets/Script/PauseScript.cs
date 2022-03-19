using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject PUI;
    public GameObject gameUI;

    bool check = false;

    void Start()
    {
        PUI.SetActive(false); //UI캔버스 비활성화
    }

    
    void Update()
    {
        PUIKey(); //Esc키를 눌렀을 때 실행되는 함수
    }

    void PUIKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            check = !check;
        }

        if (check)
        {
            PUI.SetActive(true); //멈춤UI 활성화
            gameUI.SetActive(false); //게임UI 비활성화
            Time.timeScale = 0; //시간 멈춤
        }
        else if (!check)
        {
            PUI.SetActive(false); //멈춤UI 비활성화
            gameUI.SetActive(true); //게임UI 활성화
            Time.timeScale = 1f; //시간 흐름
        }

    }

    public void Resume()
    {
        check = !check; //Esc키를 눌렀을 때와 같음
    }

    public void Restart()
    {
        SceneManager.LoadScene("SoccerGame"); //게임 불러오기
        GameObject.Find("StartSFX").GetComponent<AudioSource>().Play(); //게임 시작 효과음 재생
    }

    public void Quit()
    {
        Application.Quit(); //실행 파일 끄기
    }
}
