using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        masterSlider.value = AudioManager.Instance.GetMasterVolume();
        sfxSlider.value = AudioManager.Instance.GetSFXVolume();
        volumeSlider.value = AudioManager.Instance.GetMusicVolume();

    }
}