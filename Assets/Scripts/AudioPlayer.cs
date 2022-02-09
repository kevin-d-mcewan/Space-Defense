using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)]float shootingVolume = 1.0f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 0.5f;

    // static vars persist through all instances of a class. If we had mult AudioPlayers in the scene they would all share this STATIC INSTANCE. Great for Singletons
    private static AudioPlayer instance;


   /* public AudioPlayer GetAudioPlayer()           WOULD USE THIS FX IF USING A TRUE SINGLETON AND "instance" was public bc SINGLETONS are Public
    {
        return instance;
    }*/

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        /* Check to see if an AudioPlayer already exsists, One way to do this is with "FindObjectsOfType(GetType());"
         * "GetType()" will return the type of class we are looking at i.e. AudioPlayer
         *  Then we want to find the length of this list, so we know how many there are of that type
         *  
         */
        /*int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1) //If there is more than 1 AudioPlayer than we destroy any other AudioPlayer
        {
            gameObject.SetActive(false);    // Do this so just incase another gameObject attempts to use it before its deleted in Awake it can't
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);      // This is to allow our AudioPlayer to come with us from scene to scene (so there is no gamps in background music)
        }
        */

        if (instance != null) // if instance != null then we want to Destroy the gameObj that is trying to create itself
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            // Otherwise we want to set the gameObj to this version of the gameObj. THIS KEYWORD is equal to this version of the AudioPlayer
            /* 
             * if this is the 1st version of the audio player the "if statement above" = false AND we will set ourselves to be "this" version of the AudioPlayer
             * 
             * In English: If there is already an AudioPlayer from the previous scene we keep that AudioPlayer and use it in the next scene deleting the new one
             * trying to be made
             */
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Play shooting AudioClip
    public void PlayShootingClip()
    {
        // Call generic function and add specific variables from above for specified sound effects (**Shooting**)
        PlayClip(shootingClip, shootingVolume);
    }

    // Play Damage AudioClip 
    public void PlayDamageClip()
    {
        // Call generic function and add specific variables from above for specified sound effects (**Damage**)
        PlayClip(damageClip, damageVolume);

    }

    private void PlayClip(AudioClip clip, float volume)
    {
        // This will be called from other scripts to have audio play
        if (clip != null)
        {
            // Takes out the AudioClip(sound file) and instantiates it into the world

            // We locate our AudioClip at the location (Camera.main.transform.position) bc in 2D games that is one of the best ways
            // to make the sound play the best and not far off in the distance
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

}
