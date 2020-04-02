using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{

    //list of all radio tracks
    public List<AudioSource> radioTracks;
    public Transform trackHolder;
    public AudioSource audioSource;
    public AudioSource backgroundTrack;

    public int trackToPlay;

    //find the script that controls whether a car is drivable
    public GameObject player;

    void Start()
    {

        //get all the radio tracks
        foreach (Transform child in trackHolder)
        {
            radioTracks.Add(child.gameObject.transform.GetComponent<AudioSource>());
        }
        audioSource = radioTracks[trackToPlay];
    }

    // Update is called once per frame
    void Update()
    {
        //sets the radio to play if the player is in a car
        if (player.GetComponentInChildren<SkinnedMeshRenderer>().enabled == false)
        {
            backgroundTrack.Stop();

            //if the audio source is not playing anything
            if (!audioSource.isPlaying)
             {
                //choose a random track when a player enters a car
                trackToPlay = Random.Range(0, radioTracks.Count);
                audioSource = radioTracks[trackToPlay];
                //play some music
                audioSource.Play((ulong)trackToPlay);
                Debug.Log("Should be playing audio");
            }
      

        }
        else
        {
            //disable the radio system if the player is not in a car 
            audioSource.Stop();
            if (!backgroundTrack.isPlaying) {
                backgroundTrack.Play();
            }
        }
    }
}
