using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionManager : MonoBehaviour
{
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    public AudioMixer masterMixer;

    public void SetSfxLvl (float sfxLvl)
    {
        masterMixer.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMusicLvl (float musicLvl)
    {
        masterMixer.SetFloat("musicVol", musicLvl);
    }
}
