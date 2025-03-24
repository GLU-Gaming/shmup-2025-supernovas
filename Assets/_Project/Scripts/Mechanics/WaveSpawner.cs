using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool spawnNew = true;

    void Start()
    {
        StartCoroutine(waveSpawn());
    }

    IEnumerator waveSpawn()
    {
        while (spawnNew)
        {


            yield return new WaitForSeconds(1f);
        }
    }

}
