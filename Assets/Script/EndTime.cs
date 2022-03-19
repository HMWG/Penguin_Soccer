using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTime : MonoBehaviour
{
    Slider TimerE;

    void Start()
    {
        TimerE = GetComponent<Slider>();
        TimerE.maxValue = GameObject.Find("GameManager").GetComponent<WinScene>().playTime; // 슬라이더의 최댓값을 플레이타임으로
        TimerE.value = GameObject.Find("GameManager").GetComponent<WinScene>().playTime; // 슬라이더의 값을 플레이타임으로 시작

    }

    void Update()
    {
        if (TimerE.value > 0) //남은 플레이 타임을 보여주는 슬라이더
        {
            TimerE.value -= Time.deltaTime; //시간이 갈수록 슬라이더가 줄어듬
        }
    }
}
