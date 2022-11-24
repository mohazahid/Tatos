using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Audio;   

public class setVolume : MonoBehaviour
{
    public Slider mySlider;
    public AudioMixer mixer;
    void Awake()   
   {
        mySlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
    public void setLevel(float SliderVal) 
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(SliderVal) * 20);
        PlayerPrefs.SetFloat("MusicVolume", SliderVal);
    }    
}
