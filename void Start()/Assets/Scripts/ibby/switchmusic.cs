using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class switchmusic : MonoBehaviour
{
    public AudioClip newtrack;
    private audiomaneger theAM;
    public AudioMixerGroup Mixer;

    public void AssignMixer(AudioSource source)
    {
        source.outputAudioMixerGroup = Mixer;
    }
    void Start()
    {
        theAM = FindObjectOfType<audiomaneger>();
        if(newtrack != null)
        theAM.ChangeBGM(newtrack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
