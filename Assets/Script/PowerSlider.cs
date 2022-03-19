using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour
{
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(name == "ShootPowerSlider1") //파워의 값을 가져와 value에 넣음
        {
            slider.value = GameObject.Find("SoccerBall").GetComponent<ball>().power;
        }
        else if (name == "ShootPowerSlider2")
        {
            slider.value = GameObject.Find("SoccerBall").GetComponent<ball>().power2;
        }
            

        //GameObject.Find("Soccer Ball").GetComponent<ball>().power;
    }
}
