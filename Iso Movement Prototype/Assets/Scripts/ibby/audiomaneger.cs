using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomaneger : MonoBehaviour
{
    public AudioSource BGM;
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<audiomaneger>().Length > 1)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }
    public void ChangeBGM(AudioClip music)
    {
        if (BGM.clip.name == music.name)
            return;
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}
