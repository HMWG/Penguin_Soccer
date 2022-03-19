using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    Slider TimerS;

    void Start()
    {
        TimerS = GetComponent<Slider>();
    }

    
    void Update()
    {
        if(TimerS.value > 0) //패스 할 시 value가 5로 바뀜
        {
            TimerS.value -= Time.deltaTime; //5초 카운트 슬라이드
        }
    }

}
