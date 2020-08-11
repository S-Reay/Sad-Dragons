using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AuidoAdjust : MonoBehaviour
{
    public AudioMixer MasterMixer;

    public void SetSfxLvl(float sfxLvl)
    {
        MasterMixer.SetFloat("sfxVol", sfxLvl);
    }
    public void MusicVolume(float musicLvl)
    {
        MasterMixer.SetFloat("musicVol", musicLvl);
    }
}
