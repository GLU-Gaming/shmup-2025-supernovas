using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public bool start = false;
    public float duration = 1.0f;
    public AnimationCurve curve;

    void Update()
    {
        if (start)
        {
            StartCoroutine(Shaking());
        }
    }
    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float esapsedTime = 0f;
        while (esapsedTime < duration)
        {
            esapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(esapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;

    }
}

