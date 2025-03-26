using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public bool start = false;
    public float duration = 1.0f;
    public float intensity;

    void StartShake()
    {
        StartCoroutine(Shaking(1.0f, 0.2f));
    }
    IEnumerator Shaking(float duration, float intensity)
    {
        Vector3 startPosition = transform.position;
        float esapsedTime = 0f;
        while (esapsedTime < duration)
        {
            esapsedTime += Time.deltaTime;
            float strength = intensity;
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;

    }
}

