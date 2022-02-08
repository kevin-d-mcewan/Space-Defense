using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField] float shakeDuration = 1.0f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;

    void Start()
    {

        initialPosition = transform.position;

    }


    public void Play() 
    {
        StartCoroutine(Shake());
    }


    IEnumerator Shake()
    {
        float elapsedTime = 0f;

        // While our 'elapsedTime is < shakeDuration' we want to move Camera
        while(elapsedTime < shakeDuration)
        {

            // Casting our "Vector2 insideUnitCircle" as a "Vector3" so that 'initialPosition' can work with it
            // When casting to a Vector3 in a 2D game changes z-axis to = 0
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;

            // So, we dont have infinite loop we need to increase "elapsedTime" every second... that way it can catch up to shakeDuration
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        // reset our (camera's) transform.position back to its initial location (initialPosition)
        transform.position = initialPosition;

    }

}
