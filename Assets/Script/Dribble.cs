using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dribble : MonoBehaviour
{
    public bool canPass = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //드리블 콜라이더의 OnTriggerEnter설정 (패스 할 수 있음)
    {
        if (other.gameObject.name == "SoccerBall")
        {
            canPass = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "SoccerBall")
        {
            canPass = false;
        }
    }
}
