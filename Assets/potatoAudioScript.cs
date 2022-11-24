using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potatoAudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int SelfCounter = 0;
    private AudioSource PotatoSound;
    void Start()
    {
        PotatoSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.potatoCount != SelfCounter)
        {
            SelfCounter = Player.potatoCount;
            PotatoSound.Play();
        }
    }
}
