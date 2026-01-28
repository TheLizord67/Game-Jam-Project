using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Linq;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider soundSlider;
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private string volumeParameter;
    [SerializeField] private List<Sprite> soundImages;
    [SerializeField] private Image soundImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
        }
    }

    public void SetVolume()
    {
        float volume = soundSlider.value;
        myMixer.SetFloat(volumeParameter, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    private void LoadVolume()
    {
        soundSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        SetVolume();
    }

    public void ChangeImage()
    {
        if (soundSlider.value == 0)
        {
            soundImage.sprite = soundImages[0];
        }
        else if (soundSlider.value > .001f && soundSlider.value <= 0.33f)
        {
            soundImage.sprite = soundImages[1];
        }
        else if (soundSlider.value > 0.33f && soundSlider.value <= 0.66f)
        {
            soundImage.sprite = soundImages[2];
        }
        else if (soundSlider.value > 0.66f)
        {
            soundImage.sprite = soundImages[3];
        }
        else
        {
            Debug.Log("No image");
        }
    }

    public void Update()
    {
        ChangeImage();
    }
}
