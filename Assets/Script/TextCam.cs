using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCam : MonoBehaviour
{
    public GameObject cam;

    Vector3 startScale;
    public float distance = 6;

    void Start()
    {
        distance = 6;

        startScale = transform.localScale;
        cam = GameObject.Find("Camera");
    }

    
    void Update() //플레이어 위의 글씨가 항상 캠을 바라보고 크기 고정
    {
        float dist = Vector3.Distance(cam.transform.position, transform.position);
        Vector3 newScale = startScale * dist / distance;
        transform.localScale = newScale;

        transform.rotation = cam.transform.rotation;
    }
}
