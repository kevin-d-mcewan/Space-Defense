using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    /* This script determines how much HEALTH the GameObject attached has*/

    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    //DamageDealer damageDealer;

    [Header("Visual FX")]
    [SerializeField] ParticleSystem hitEffect;

    CameraShake cameraShake;
    // control who this is attached to
    [SerializeField] bool applyCameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;


    private void Awake()
    {
        // This camera obj has a find type already build into it (Camera.main [main camera on scene])... & get the CameraShake component
        cameraShake = Camera.main.GetComponent<CameraShake>();

        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // This checks to see if GameObject that collided has the component "DamageDealer"
        // If sucessful will get their damage # else it will be a null value
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            // Take Damage
            TakeDamage(damageDealer.GetDamage());

            // Call and Play hit effect
            PlayHitEffect();

            // Call and Play the ShakeCamera Effect function
            ShakeCamera();

            audioPlayer.PlayDamageClip();

            // tell damage dealer it hit something so it can destroy itself
            damageDealer.Hit();

        }


    }

    private void TakeDamage(int damage)
    {
        // damage = damageDealer.GetDamage();   *** Don't need this bc passing GetDamage() from above

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        // If we have attached a hitEffect (hitEffect component is on gameObject this is attached to) we would like to play...
        if (hitEffect != null)
        {
            // Putting it in a temp var so we can Destroy() it later
            // If hitEffect happens going to Instantiate HitEffect and the place collision happened (transform.position) and no rotation
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);

            // For Destroy() we are destroying the gameObj attached to instance, for the duration of how long until we destroy depends on how we setup
            // the ParticleEffect (two constants, curve, 2 curves...) so instance.main.duration is how long its set up for and instance.main.startLifetime...
            // is for how long the particle effect is set up to run
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);

        }
    }


    private void ShakeCamera()
    {
        // "cameraShake != null" means that we've been able to find this component on the camera && if we should apply the camera shake at all (applyCameraShake)
        if (cameraShake != null && applyCameraShake)
        {
            // call and run "Play()" from the CameraShake script
            cameraShake.Play();
        }
    }


    public int GetHealth()
    {
        return health;
    }

    
}
