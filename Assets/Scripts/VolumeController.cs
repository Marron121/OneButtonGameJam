using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audio;

    [SerializeField]
    private Toggle sound;

    [SerializeField]
    private Toggle music;
    // Start is called before the first frame update
    void Start()
    {
        float soundVol, musicVol;
        audio.GetFloat("MusicVolume", out musicVol);
        audio.GetFloat("SoundVolume", out soundVol);
        if (soundVol < 0) sound.SetIsOnWithoutNotify(true);
        if (musicVol < 0) music.SetIsOnWithoutNotify(true);
    }

    public void ChangeSoundState(bool state)
    {
        state = !state;
        if (state)
        {
            audio.SetFloat("SoundVolume", 0);
        }
        else
        {
            audio.SetFloat("SoundVolume", -80);
        }
    }

    public void ChangeMusicState(bool state)
    {
        state = !state;
        if (state)
        {
            audio.SetFloat("MusicVolume", 0);
        }
        else
        {
            audio.SetFloat("MusicVolume", -80);
        }
    }
}
