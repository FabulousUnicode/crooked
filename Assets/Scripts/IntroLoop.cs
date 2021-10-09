using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLoop : MonoBehaviour
{
    [SerializeField] private AudioClip main;
    private bool loopStarted = false;
    private AudioSource AudioPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!loopStarted && !AudioPlayer.isPlaying)
        {
            AudioPlayer.clip = main;
            AudioPlayer.Play();
            loopStarted = true;
            AudioPlayer.loop = true;
        }
    }
}



