using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject SkinPanel;
    /*public GameObject PausePanel;*/

    public GameObject ResetConfirmPanel;
    public GameObject ResetAlertPanel;

    public GameObject Skin1;
    public GameObject Skin2;
    public GameObject Skin3;

    public Image selectCharacter;
    [SerializeField] Image[] characterSprites;

    private void Start()
    {
        SpriteChange();
        InitSprite();
        Time.timeScale = 1.0f;
    }

    public void GameStart() //스타트 버튼 누를시 메인씬 로드 , Retry 버튼에도 적용
    {
        SoundManager.Instance.PlaySFX(SFX.Button);

        SceneManager.LoadScene("MainScene");
    }

    public void ReturnMainScene() //메인씬으로 
    {
        SoundManager.Instance.PlaySFX(SFX.Button);

        SceneManager.LoadScene("StartScene");
    }

    public void ShowOptionPanel() //옵션창 열기,닫기
    {
        if (optionPanel.activeSelf == true)
        {
            optionPanel.SetActive(false);
        }
        else if (optionPanel.activeSelf == false)
        {
            optionPanel.SetActive(true);
        }
        SoundManager.Instance.PlaySFX(SFX.Button);
    }

    public void ShowSkinPanel() //스킨창 열기 닫기
    {
        SkinPanel.SetActive(!SkinPanel.activeSelf);

        SoundManager.Instance.PlaySFX(SFX.Button);
    }



    public void ShowResetConfirmPanel() // 데이터 삭제 확인창
    {
        if (ResetConfirmPanel.activeSelf == true)
        {
            ResetConfirmPanel.SetActive(false);
        }
        else if (ResetConfirmPanel.activeSelf == false)
        {
            ResetConfirmPanel.SetActive(true);
        }
        SoundManager.Instance.PlaySFX(SFX.Button);
    }

    public void ShowResetAlertPanel() // 초기화 알림창
    {
        if (ResetAlertPanel.activeSelf == true)
        {
            ResetAlertPanel.SetActive(false);
        }
        else if (ResetAlertPanel.activeSelf == false)
        {
            ResetAlertPanel.SetActive(true);
        }
        SoundManager.Instance.PlaySFX(SFX.Button);
    }

    public void DeleteData() // 데이터 삭제
    {
        PlayerPrefs.DeleteAll();

        SoundManager.Instance.PlaySFX(SFX.Button);
    }


    public void ChangeSkinLeft() // 왼쪽 버튼 눌렀을 경우 스킨 변경, 체크 필요
    {
        List<GameObject> list = new List<GameObject>();
        list.Add(Skin1);
        list.Add(Skin2);
        list.Add(Skin3);
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].activeSelf)
            {
                list[i].SetActive(false);
                if (i == 0)
                {
                    list[2].SetActive(true);
                }
                else
                {
                    list[i - 1].SetActive(true);
                }
                break;
            }
        }
    }

    public void ChangeSkinRight() // 오른쪽 버튼 눌렀을 겨웅 스킨 변경, 체크 필요
    {
        List<GameObject> list = new List<GameObject>();
        list.Add(Skin1);
        list.Add(Skin2);
        list.Add(Skin3);
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].activeSelf)
            {
                list[i].SetActive(false);
                if (i == 2)
                {
                    list[0].SetActive(true);
                }
                else
                {
                    list[i + 1].SetActive(true);
                }
                break;
            }
        }
    }

    public void SelectCharacter(int index)
    {
        CharacterManager.instance.selectIndex = index;
        SpriteChange();
        ShowSkinPanel();

        SoundManager.Instance.PlaySFX(SFX.Button);
    }

    private void SpriteChange()
    {
        // selectCharacter.sprite = CharacterManager.instance.Characters[CharacterManager.instance.selectIndex].sprite;
    }

    void InitSprite()
    {
        for (int i = 0; i < characterSprites.Length; i++)
        {
            characterSprites[i].sprite = CharacterManager.instance.Characters[i].sprite;
        }
    }

    public void GameExit() // 게임 종료
    {
        // Application.Quit()만 있으면 에디터는 종료되지 않아서 전처리기 지시어 사용

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }

    public void OnePlayer()
    {
        /*GameManager.instance.player2.SetActive(true);*/
        // 게임매니저 인스턴스를 불러오려고 했으나, 스타트 씬 버튼을 누르는 상황에서
        // 아직 메인 씬이 로드되지 않았기 때문에 인스턴스화 된 캐릭터 매니저에 int형 변수를 담아 설정
        CharacterManager.instance.NumberOfPlayer = 1;
    }
    public void TwoPlayer()
    {
        CharacterManager.instance.NumberOfPlayer = 2;
    }
}