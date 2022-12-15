using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;  
public class MainMenuAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    void Start()
    {
        PlayerPrefs.SetFloat("MusicVolume", 0.2f);
        audioMixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 0.4f)) * 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
