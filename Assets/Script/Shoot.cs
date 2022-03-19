using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    public bool canShoot = false;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) //슛 콜라이더의 OnTriggerEnter 설정(공을 찰 수 있음)
    {
        if (other.gameObject.name == "SoccerBall")
        {
            canShoot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "SoccerBall")
        {
            canShoot = false;
        }
    }
}
