using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] private AudioClip[] tracks;
    private AudioSource MusicManager;
    private AudioClip currentTrack, nextTrack;

    // Start is called before the first frame update
    void Start()
    {
        MusicManager = GetComponent<AudioSource>();
        currentTrack = tracks[0];
}

    private void OnLevelWasLoaded(int level)
    {

        switch (SceneManager.GetActiveScene().name) 
        {
            case "Barn":
                nextTrack = null;
                break;
            
            case "Camp":
                nextTrack = tracks[0];
                break;

            case "Church Roof":
                nextTrack = null;
                break;

            case "Church":
                nextTrack = null;
                break;

            case "Farm":
                nextTrack = tracks[0];
                break;

            case "Field":
                nextTrack = tracks[0];
                break;

            case "Path":
                nextTrack = tracks[0];
                break;

            case "Randy's Shack":
                nextTrack = null;
                break;

            case "Shipwreck":
                nextTrack = null;
                break;

            case "Shop":
                nextTrack = tracks[1];
                break;

            case "Thorns":
                nextTrack = tracks[0];
                break;

            case "Tunnel":
                nextTrack = tracks[1];
                break;

            case "Woods":
                nextTrack = tracks[1];
                break;
        } 


        if (nextTrack != currentTrack)
        {
            currentTrack = nextTrack;
            MusicManager.clip = currentTrack;
            MusicManager.Play();
            
        }

        
    }
}
