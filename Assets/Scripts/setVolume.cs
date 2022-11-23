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
        mySlider.value = PlayerPrefs.GetFloat("key", 0.5f); 
    }
    public void setLevel(float SliderVal) 
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(SliderVal) * 20);
        PlayerPrefs.SetFloat("key", Mathf.Log10(SliderVal) * 20);
        mySlider.value = SliderVal;  
    }

    public void LoadValues() 
    {
        float value = PlayerPrefs.GetFloat("key", 0.75f);
        mixer.SetFloat("MusicVol", value);
        mySlider.value = value;
    }
     
}
