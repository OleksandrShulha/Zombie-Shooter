using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float skakeDuration = 1f;
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
        float elaosedTime = 0f;
        while(elaosedTime < skakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elaosedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
}
