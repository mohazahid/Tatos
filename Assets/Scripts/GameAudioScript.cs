using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] ambient;
    public GameObject GetOver;
    private AudioSource GetOverAudio;
    bool first = true;
    void Start()
    {
        GetComponent<AudioSource>().clip = ambient[0];
        GetComponent<AudioSource>().Play();
        GetOverAudio = GetOver.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.potatoCount >= 4)
        {
            PlayScary();
        }
    }



    void PlayScary() {
        if(first) {
            GetOverAudio.Play();
            first = false;  
        }
        GetComponent<AudioSource>().clip = ambient[1];
        
        if (!GetComponent<AudioSource>().isPlaying)
        {
        GetComponent<AudioSource>().Play();
        }
    }
}
