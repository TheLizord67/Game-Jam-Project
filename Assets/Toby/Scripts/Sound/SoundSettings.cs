using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Linq;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider soundSlider;
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private List<Sprite> soundImages;
    [SerializeField] private Image soundImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100f));
    }

    public void SetVolume(float volume)
    {
        if (volume < 1)
        {
            volume = .001f;
        }

        RefreshSlider(volume);
        PlayerPrefs.SetFloat("SavedMasterVolume", volume);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(volume / 100) * 20);
    }

    public void ChangeImage()
    {
        if (soundSlider.value == .001f)
        {
            soundImage.sprite = soundImages[0];
        }
        else if (soundSlider.value > .001f && soundSlider.value <= 33f)
        {
            soundImage.sprite = soundImages[1];
        }
        else if (soundSlider.value > 33f && soundSlider.value <= 66f)
        {
            soundImage.sprite = soundImages[2];
        }
        else if (soundSlider.value > 66f)
        {
            soundImage.sprite = soundImages[3];
        }
        else
        {
            Debug.Log("No image");
        }
    }
    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    private void RefreshSlider(float volume)
    {
        soundSlider.value = volume;
    }

    public void Update()
    {
        ChangeImage();
    }
}
