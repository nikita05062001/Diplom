using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;
    private float soundVolume = 1f;
    public Text ПроцентМузыки;
    public Slider СлайдерМузыки;
    public Text ПроцентЗвуков;
    public Slider СлайдерЗвуков;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("SoundVolume")) PlayerPrefs.SetFloat("SoundVolume", 1f);
        if (!PlayerPrefs.HasKey("MusicVolume")) PlayerPrefs.SetFloat("MusicVolume", 1f);
        audioSrc.volume = PlayerPrefs.GetFloat("MusicVolume");
        СлайдерМузыки.value = PlayerPrefs.GetFloat("MusicVolume");
        СлайдерЗвуков.value = PlayerPrefs.GetFloat("SoundVolume");
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
        ПроцентМузыки.text =(100f*PlayerPrefs.GetFloat("MusicVolume")).ToString("f0")+"%";
        ПроцентЗвуков.text = (100f * PlayerPrefs.GetFloat("SoundVolume")).ToString("f0") + "%";
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }
    public void SetSound(float vol)
    {
        soundVolume = vol;
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }
}
