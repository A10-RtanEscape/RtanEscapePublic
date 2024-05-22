using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSliderController : MonoBehaviour
{
    public Slider bgmSlider;

    private void Start()
    {
        float _bgmVol = PlayerPrefs.GetFloat("bgmVol", 1f); // 값이 비어있을 때 1f로 설정
        bgmSlider.value = _bgmVol;

        // SoundManager에 있는 bgmSlider에 전달
        SoundManager.Instance.bgmSlider = this.bgmSlider;
    }
}
