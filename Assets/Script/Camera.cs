using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target1; //플레이어 1
    public Transform target2; //플레이어 2
    public Vector3 offset; //카메라와 플레이어 사이의 추가거리


   
    void Update()
    {
        transform.position = (target1.position + target2.position)/2 + offset; //플레이어 사이의 거리 + 추가거리
        SetPos();
    }

    void SetPos() //플레이어 사이의 거리에 따른 offset의 조절
    {
        Vector3 velo = Vector3.zero;
        
        if(Vector3.Distance(target1.position, target2.position) < 3)
        {
            offset = Vector3.SmoothDamp(offset,new Vector3(0, 1.75f, -2.55f), ref velo, 0.1f); //부드럽게 위치가 조절
        }

        else if (Vector3.Distance(target1.position, target2.position) > 3 && Vector3.Distance(target1.position, target2.position) < 5f)
        {
            offset = Vector3.SmoothDamp(offset, new Vector3(0, 2.5f, -4f), ref velo, 0.1f);
        }

        else if (Vector3.Distance(target1.position, target2.position) > 5f && Vector3.Distance(target1.position, target2.position) < 7f)
        {
            offset = Vector3.SmoothDamp(offset, new Vector3(0, 3.5f, -5f), ref velo, 0.1f);
        }

        else if (Vector3.Distance(target1.position, target2.position) > 7f && Vector3.Distance(target1.position, target2.position) < 9f)
        {
            offset = Vector3.SmoothDamp(offset, new Vector3(0, 5f, -6.5f), ref velo, 0.1f);
        }

        else if (Vector3.Distance(target1.position, target2.position) > 9f && Vector3.Distance(target1.position, target2.position) < 12f)
        {
            offset = Vector3.SmoothDamp(offset, new Vector3(0, 6f, -7.5f), ref velo, 0.1f);
        }

        else if (Vector3.Distance(target1.position, target2.position) > 12f)
        {
            offset = Vector3.SmoothDamp(offset, new Vector3(0, 6.5f, -9.5f), ref velo, 0.1f);
        }


    }
}
