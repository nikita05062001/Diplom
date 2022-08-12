using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolumeValue : MonoBehaviour
{
    private AudioSource AudioSrc;
    public bool sound;
    public bool music;
    // Start is called before the first frame update
    void Start()
    {
        AudioSrc = GetComponent<AudioSource>();
        if (sound == true) AudioSrc.volume = PlayerPrefs.GetFloat("SoundVolume");
        if (music == true) AudioSrc.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
