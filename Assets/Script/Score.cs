using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scr1;
    public int scr2;

    void Start()
    {
        scr1 = 0; //점수 초기화
        scr2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = scr1 + " : " + scr2; //점수 텍스트 설정

        
    }
}
