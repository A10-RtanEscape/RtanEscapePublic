using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject shit; // object로 선언이 안돼서 임시 이름....
    public GameObject clearItem;
    public GameObject player;
    public GameObject player2;
    public Text PlayerTxt;
    public Text Player2Txt;
    float rate = 0.3f;
    float time = 0.0f;
    public GameObject endPanel;
    public Text score; //좌측상단 점수 표기
    public Text best;
    public Text panelScore;
    public Text panelBest;
    string key; // 스코어 저장할 키값
    int nowScore;
    int bestScore;
    private bool PlayedEndPanelSFX = false; // 엔드 판넬 재생 여부 상태

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeShit", 0f, rate);

        int highScore = PlayerPrefs.GetInt(key);

        best.text = highScore.ToString();

        if (CharacterManager.instance.NumberOfPlayer == 1)
        {
            player2.SetActive(false);
        }
        else
        {
            player2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        FolliowTxt();
        if (endPanel.activeSelf == true)
        {
            if (PlayedEndPanelSFX == false)
            {
                SoundManager.Instance.PlaySFX(SFX.EndPanel);
                PlayedEndPanelSFX = true; // 효과음 재생 됐으니 상태 변경
            }

            Time.timeScale = 0.0f;
            EndGame();
        }
        else
        {
            Time.timeScale = 1.0f;
            PlayedEndPanelSFX = false; // 엔드 판넬 꺼지면 효과음 재생되도록 상태 변경
        }
    }

    private void MakeShit()
    {
        Debug.Log("경과 시간 확인 :" + time);

        GameObject obj = Instantiate(shit);

        if (time > 10.0f && time <= 20.0f) // 경과시간이 10초 이상일 경우 30% 확률로 추가적인 오브젝트 생성
        {
            float p = UnityEngine.Random.Range(0, 10);
            if (p < 3) Instantiate(shit);
        }
        else if (time > 20.0f && time <= 30.0f) //20초 이상일 경우 50% 확률로 추가적인 오브젝트 생성
        {
            float p = UnityEngine.Random.Range(0, 10);
            if (p < 5) Instantiate(shit);
        }
        else if (time > 30.0f) // 30초 이상일 경우 80% 확률로 추가적인 오브젝트 생성 + 10% 확률로 아이템 생성
        {
            float p = UnityEngine.Random.Range(0, 10);
            if (p < 1)
            {
                Instantiate(clearItem);
                Instantiate(shit);
            }
            else if (p < 8)
            {
                Instantiate(shit);
            }
        }
    }

    private void EndGame()
    {
        nowScore = int.Parse(score.text);

        if (PlayerPrefs.HasKey(key))
        {
            int best = PlayerPrefs.GetInt(key);

            if (best < nowScore)
            {
                PlayerPrefs.SetInt(key, nowScore);
                bestScore = nowScore;
            }
            else
            {
                bestScore = best;
            }

        }
        else
        {
            PlayerPrefs.SetInt(key, nowScore);
            bestScore = nowScore;
        }

        panelScore.text = score.text;
        panelBest.text = best.text;
    }

    private void FolliowTxt()
    {
        PlayerTxt.transform.position = new Vector2(player.transform.position.x*77+960, PlayerTxt.transform.position.y);
        if (player2.activeSelf == true)
        {
            Player2Txt.transform.position = new Vector2(player2.transform.position.x*77+960, Player2Txt.transform.position.y);
        }
        Debug.Log(player.transform.position.x);
    }
}