using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hAxis;
    float vAxis;
    public float speed = 3;
    public bool isMove = false;
    public float power = 3;
    bool check=false;

    public Vector3 moveVec; //움직이는방향

    Animator ani;

    GameObject SB; //SoccerBall
  
    void Start()
    {
        ani = GetComponent<Animator>();
        SB = GameObject.Find("SoccerBall"); //SoccerBall
    }

    void Update()
    {
        Move();  
    }

    public void Move()
    {
        if (name == "Player1") //플레이어 1
        {
            hAxis = Input.GetAxis("Horizontal"); //수평방향벡터를 받는 키 (a, d)
            vAxis = Input.GetAxis("Vertical"); //수직방향벡터를 받는 키 (w, s)
        }
        else if (name == "Player2") //플레이어 2
        {
            hAxis = Input.GetAxis("Horizontal2"); //수평방향벡터를 받는 키 (up, down)
            vAxis = Input.GetAxis("Vertical2"); //수직방향벡터를 받는 키 (left, right)
        }

         
        if (hAxis == 0 && vAxis == 0) //움직이고 있는지 멈춰있는지를 나타냄
        {
            isMove = false; 
        }
        else
        {
            isMove = true;
        }

        moveVec = new Vector3(hAxis, 0, vAxis).normalized; //입력된 값을 토대로 이동할 방향벡터 설정

        transform.position += moveVec * speed * Time.deltaTime; //방향벡터의 방향으로 움직임

        if (isMove) //움직일 때 움직이는 방향을 바라보고 걷는 애니메이션
        {
            if(!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            
            
            transform.LookAt(transform.position + moveVec); //움직이는 방향으로 바라보는 함수
            ani.SetInteger("Walk", 1);
        }
        else //걷는 애니메이션 끄기
        {
            gameObject.GetComponent<AudioSource>().Stop();
            ani.SetInteger("Walk", 0);
        }

        if (check==true) //플레이어끼리 부딪혔을 때 딜레이
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait() //딜레이 시간
    {
        yield return new WaitForSeconds(1f);
        check = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "SoccerBall") //SoccerBall과 부딪혔을 때 공이 튕겨짐 (드리블)
        {
            SB.GetComponent<Rigidbody>().velocity = ((SB.transform.position - transform.position).normalized * power); //공이 플레이어의 반대방향으로 튕겨짐
        }

        else if (collision.gameObject.tag == "Player") //플레이어와 부딪혔을 때 몸이 튕겨짐
        {
            check = true; //움직임 딜레이 작동
            GetComponent<Rigidbody>().velocity = (-moveVec).normalized * 5; //움직이는 방향의 반대방향으로 튕겨짐
        }
    }
   
    

}
