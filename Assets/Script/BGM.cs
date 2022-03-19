using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    GameObject bgm;
    AudioSource BMusic;
    public AudioClip startBGM;
    public AudioClip gameBGM;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        bgm = GameObject.Find("SoundManager");
        BMusic = bgm.GetComponent<AudioSource>();

        BMusic.volume = 0.08f; //배경음악 볼륨 설정
        BMusic.clip = startBGM; //시작 배경음악으로 설정
        BMusic.Play(); //배경음악 재생
        DontDestroyOnLoad(bgm); //장면이 바뀌어도 오브젝트가 사라지지 않음 (배경음악 재생 유지)
    }

    public void ChangeBGM()
    {
        if (!BMusic.isPlaying || BMusic.clip == startBGM)
        {
            BMusic.clip = gameBGM; //게임 배경음악으로 설정
            BMusic.Play(); //배경음악 시작
        }
       
    }
}
