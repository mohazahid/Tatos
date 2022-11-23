using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] ambient;
    void Start()
    {
        GetComponent<AudioSource>().clip = ambient[0];
        GetComponent<AudioSource>().Play();
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
        GetComponent<AudioSource>().clip = ambient[1];

        if (!GetComponent<AudioSource>().isPlaying)
        {
        GetComponent<AudioSource>().Play();
        }
    }
}
