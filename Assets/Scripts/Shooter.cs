using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10.0f;
    [SerializeField] float projectileLifetime = 5.0f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0.0f;
    [SerializeField] float minFiringRate = 0.1f;

    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;    // var of AudioPlayer to create a ref for it

    private void Awake()
    {
        // Creating a ref to our AudioPlayer Script to be used by this script
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }


    void Start()
    {
        if (useAI == true)
        {
            isFiring = true;
        }
    }

    
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        // 'firingCoroutine == null' will be null once the first shot is fired
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null )
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;         // This will change the Coroutine to null completely bc with "StopCoroutine" there is still something there
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Creating a ref to the projectile RigidBody. Then giving it a velocity
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Set RigidBody Velocity by giving it a "direction & speed". 'transform.up' has a magnitude of 1 and we will multiply that by the speed we set
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);

            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minFiringRate, float.MaxValue);

            // Plays the Audio Shooting Clip in this Coroutine
            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }


}
