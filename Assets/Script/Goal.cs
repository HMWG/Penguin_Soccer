using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{

    bool check;

    Vector3 ballPos;
    Vector3 p1Pos;
    Vector3 p2Pos;


    void Start()
    {
        ballPos = GameObject.Find("SoccerBall").transform.position; //공의 원래 위치 기억
        p1Pos = GameObject.Find("Player1").transform.position; //플레이어1의 원래 위치 기억
        p2Pos = GameObject.Find("Player2").transform.position; //플레이어1의 원래 위치 기억
        GameObject.Find("GoalText").GetComponent<Text>().text = "★Goal★"; //골 텍스트 설정
        GameObject.Find("GoalText").GetComponent<Text>().enabled = false; //골 텍스트 안보이게 설정
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //골 콜라이더에 닿으면 골 선언
    {
        if (other.gameObject.name == "SoccerBall")
        {
            GameObject.Find("GoalText").GetComponent<Text>().enabled = true; //골 텍스트가 보이게 설정

            if(name == "GoalCollider1")
            {
                GameObject.Find("ScoreText").GetComponent<Score>().scr2++; //점수 올라감
            }
            else if (name == "GoalCollider2")
            {
                GameObject.Find("ScoreText").GetComponent<Score>().scr1++;
            }
            
            GameObject.Find("GoalText").GetComponent<AudioSource>().Play(); //골 효과음 재생

            Invoke("Reset", 3); //3초 후 리셋

            gameObject.SetActive(false); //골 콜라이더 비활성화 (연속으로 득점을 방지)
                

        }
    }

    public void Reset() //리셋 함수
    {
        GameObject.Find("GoalText").GetComponent<Text>().enabled = false; //골 텍스트 안보이게 설정
        GameObject.Find("SoccerBall").transform.position = ballPos; //공을 시작 위치로
        GameObject.Find("Player1").transform.position = p1Pos; //플레이어1을 시작 위치로
        GameObject.Find("Player2").transform.position = p2Pos;//플레이어2을 시작 위치로
        gameObject.SetActive(true); //골 콜라이더 활성화
        GameObject.Find("GoalCollider1").GetComponent<AudioSource>().Play();
        if (name == "GoalCollider1")
        {
            GameObject.Find("SoccerBall").GetComponent<Rigidbody>().velocity = new Vector3(-0.5f, 0, 0);
        }
        else if(name == "GoalCollider2")
        {
            GameObject.Find("SoccerBall").GetComponent<Rigidbody>().velocity = new Vector3(0.5f, 0, 0);
        }
    }
}
