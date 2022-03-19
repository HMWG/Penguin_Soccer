using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    public float power = 50;
    public float power2 = 50;
    bool check = true;
    Vector3 direction;

    public AudioClip shootSFX; //슛 효과음
    public AudioClip passSFX; //패스 효과음

    void Start()
    {
        power = 50;
        power2 = 50;
        GameObject.Find("Arrow").GetComponent<MeshRenderer>().enabled = false; //화살표의 모습을 감춤
    }


    void Update()
    {
        TryShoot(); //공을 차는 함수
        findDir(); //공을 찰 방향을 정하는 함수
        TryPass(); //공을 머리 위로 띄우는 함수
        ArrowPos(); //공의 위치를 가리키는 화살표 함수
            
    }

    void findDir() //공을 찰 방향을 정하는 함수
    {
        if((GameObject.Find("ShootCollider1").GetComponent<Shoot>().canShoot == true)) //플레이어 1 슛 콜라이더에 OnTriggerEnter가 작동되었을 때
        {
            if (GameObject.Find("Player1").GetComponent<Player>().isMove == true) //플레이어 1이 움직일 때 (움직이지 않으면 가장 최근에 설정 된 방향벡터가 남아있음)
            {
                direction = (GameObject.Find("Player1").GetComponent<Player>().moveVec + new Vector3(0, 1f, 0)).normalized;
                //공이 날라갈 방향벡터 설정 ( 포물선 효과를 주기위해 y축으로 1 더해줌)
            }
        }

        if ((GameObject.Find("ShootCollider2").GetComponent<Shoot>().canShoot == true)) //플레이어 2
        {
            if (GameObject.Find("Player2").GetComponent<Player>().isMove == true)
            {
                direction = (GameObject.Find("Player2").GetComponent<Player>().moveVec + new Vector3(0, 1f, 0)).normalized;
            }
        }

    }

    void TryShoot() //공을 차는 함수
    {
        if (Input.GetKeyDown(KeyCode.Space)) //슛 키를 눌렀을 때 파워 초기화
        {
            power = 50;
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            power2 = 50;
        }

        if (Input.GetKey(KeyCode.Space) && power < 300) //슛 키룰 누르고 있으면 파워 조절
        {
            power += 320 * Time.deltaTime; //누르고 있으면 파워가 올라감
            
            if(power > 299)
            {
                power = 50; //파워가 꽉 차면 초기화
            }
        }
        if (Input.GetKey(KeyCode.KeypadEnter) && power < 300) //플레이어2
        {
            power2 += 320 * Time.deltaTime;
            
            if (power2 > 299)
            {
                power2 = 50;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && (GameObject.Find("ShootCollider1").GetComponent<Shoot>().canShoot == true)) //키를 뗐을 때 && 슛 콜라이더에 OnTriggerEnter가 작동되었을 때
        {
            GetComponent<Rigidbody>().AddForce(direction * power); //주어진 방향으로 힘을 가함
            GameObject.Find("SoccerBall").GetComponent<AudioSource>().clip = shootSFX; //슛 효과음 설정
            GameObject.Find("SoccerBall").GetComponent<AudioSource>().Play(); //슛 효과음 재생
        }
        if (Input.GetKeyUp(KeyCode.KeypadEnter) && (GameObject.Find("ShootCollider2").GetComponent<Shoot>().canShoot == true)) //플레이어2
        {
            GetComponent<Rigidbody>().AddForce(direction * power2);
            GameObject.Find("SoccerBall").GetComponent<AudioSource>().clip = shootSFX;
            GameObject.Find("SoccerBall").GetComponent<AudioSource>().Play();
        }
        



    }


    void TryPass() //공을 머리 위로 띄우는 함수
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && (GameObject.Find("DribbleCollider1").GetComponent<Dribble>().canPass == true) && check) //패스 키 && 드리블 콜라이더 OnTriggerEnter가 작동되었을 때 && 딜레이체크가 true일 때
        {
            check = false; //딜레이 체크
            GetComponent<Rigidbody>().velocity = (GameObject.Find("Player1").transform.position - transform.position)*1.25f + new Vector3(0, 4.75f, 0); //공을 머리위로 띄움
            GameObject.Find("SoccerBall").GetComponent<AudioSource>().clip = passSFX; //패스 효과음 설정
            GameObject.Find("SoccerBall").GetComponent<AudioSource>().Play(); //패스 효과음 재생
            StartCoroutine(Wait()); //딜레이 시작
            GameObject.Find("Timer").GetComponent<Slider>().value = 5; //딜레이 타이머 시작
        }
        else if (Input.GetKeyDown(KeyCode.Keypad0) && (GameObject.Find("DribbleCollider2").GetComponent<Dribble>().canPass == true) && check) //플레이어2
        {
            check = false;
            GetComponent<Rigidbody>().velocity = (GameObject.Find("Player2").transform.position - transform.position) * 1.25f + new Vector3(0, 4.75f, 0);
            GameObject.Find("SoccerBall").GetComponent<AudioSource>().clip = passSFX;
            GameObject.Find("SoccerBall").GetComponent<AudioSource>().Play();
            StartCoroutine(Wait2());
            GameObject.Find("Timer2").GetComponent<Slider>().value = 5;
        }
    }


    IEnumerator Wait() //딜레이 시간
    {
        yield return new WaitForSeconds(5); //5초 대기
        check = true;
    }

    IEnumerator Wait2() //플레이어2
    {
        yield return new WaitForSeconds(5);
        check = true;
    }

    void OnBecameInvisible()//공이 안보일 때 화살표 보임
    {
        GameObject.Find("Arrow").GetComponent<MeshRenderer>().enabled = true;
    }

    void OnBecameVisible()//공이 보이면 화살표 사라짐
    {
        GameObject.Find("Arrow").GetComponent<MeshRenderer>().enabled = false;
    }

    void ArrowPos() //화살표가 공의 방향을 가리키는 함수
    {   //플레이어 사이에 화살표 위치 고정
        GameObject.Find("Arrow").transform.position = (GameObject.Find("Player1").transform.position + GameObject.Find("Player2").transform.position) / 2 + new Vector3(0, 0.5f, 0);
        GameObject.Find("Arrow").transform.LookAt(transform.position + new Vector3(0,-90,0));
    }




}
