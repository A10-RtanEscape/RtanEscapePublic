using UnityEngine;
using UnityEngine.UI;
public class SFXSliderController : MonoBehaviour
{
    public Slider sfxSlider;

    private void Start()
    {
        float _sfxVol = PlayerPrefs.GetFloat("sfxVol", 1f); // 값이 비어있을 때 1f로 설정
        sfxSlider.value = _sfxVol;

        // SoundManager에 있는 bgmSlider에 전달
        SoundManager.Instance.sfxSlider = this.sfxSlider;
    }
}