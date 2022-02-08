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
