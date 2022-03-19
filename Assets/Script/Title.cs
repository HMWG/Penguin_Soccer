using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string SCGame;
    bool check = false;
    

    void Start()
    {
        SCGame = "SoccerGame";
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "StartScene") //시작 씬에서 아무 키나 누르면 게임 시작
        {
            if (Input.anyKeyDown) //아무키나 누르면
            {
                LoadGame(); //로드 게임 함수 실행
                GameObject.Find("SoundManager").GetComponent<BGM>().ChangeBGM();
            }
        }
        else if(SceneManager.GetActiveScene().name == "EndScene1" || SceneManager.GetActiveScene().name == "EndScene2" || SceneManager.GetActiveScene().name == "EndScene3")
        {       //엔딩 씬에서 아무 키나 누르면 게임 시작
            StartCoroutine(Wait()); //게임이 종료 될 때 키를 누르고있는 상황에 바로 게임 시작 되는것을 방지

            if (Input.anyKeyDown && check)
            {
                check = false;
                LoadGame();
                GameObject.Find("SoundManager").GetComponent<BGM>().ChangeBGM();
            }
        }
        
    }

    IEnumerator Wait() //딜레이 시간
    {
        yield return new WaitForSeconds(5);
        check = true;
    }



    public void LoadGame() //버튼이 클릭되면 게임 씬으로 넘어가는 함수
    {
        SceneManager.LoadScene(SCGame); //게임 불러오기
        GameObject.Find("StartSFX").GetComponent<AudioSource>().Play(); //게임 시작 효과음 재생

    }


}
