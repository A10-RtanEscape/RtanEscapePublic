using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public Slider bgmSlider;
    public AudioSource audioSource;

    private float _bgmVol = 1f;

    [Header("SFX")]
    public Slider sfxSlider;
    private float _sfxVol = 1f;
    private int channelCount = 10;
    public AudioClip[] sfxClips;
    public AudioSource[] sfxPlayers;
    private int sfxIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 넘어가도 파괴되지 않게
        }
        else
        {
            Destroy(gameObject); // 처음 만들어진 싱글톤을 제외하고 파괴
        }
    }

    void Start()
    {   // 값 불러오기, 재실행 해도 유지
        _bgmVol = PlayerPrefs.GetFloat("bgmVol", 1f); // 값이 비어있을 때 1f로 설정
        bgmSlider.value = _bgmVol;
        audioSource.volume = bgmSlider.value;


        _sfxVol = PlayerPrefs.GetFloat("sfxVol", 1f);
        GameObject sfxObject = new GameObject("Sfx Player");
        sfxObject.transform.parent = transform;

        sfxPlayers = new AudioSource[channelCount];

        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].volume = _sfxVol;
        }

    }

    private void Update()
    {
        BgmSlider();
    }

    public void BgmSlider()
    {
        // null값 일 때 오류나지 않게 하기
        if (bgmSlider != null)
        {
            audioSource.volume = bgmSlider.value;

            _bgmVol = bgmSlider.value;
            PlayerPrefs.SetFloat("bgmVol", _bgmVol); // 값 저장
        }


        // null값 일 때 오류나지 않게 하기
        if (sfxSlider != null)
        {
            for (int i = 0; i < sfxPlayers.Length; i++)
            {
                sfxPlayers[i].volume = sfxSlider.value;
                _sfxVol = sfxSlider.value;
            }

            PlayerPrefs.SetFloat("sfxVol", _sfxVol); // 값 저장
        }
    }

    public void PlaySFX(SFX sfx)
    {
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            int loopIndex = (i + sfxIndex) % sfxPlayers.Length;

            // 해당 인덱스 채널이 이미 효과음을 재생중이라면 다음 채널로 넘어간다.
            if (sfxPlayers[loopIndex].isPlaying)
            {
                continue;
            }

            sfxIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;

        }
    }
}

public enum SFX
{
    Walk = 0,
    Button = 1,
    Bomb = 2,
    EndPanel = 3,
    Item = 4,
}