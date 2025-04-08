using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawning : MonoBehaviour
{

    public float loadInGracePeriod; // Time until anything actually happens
    public float waveCooldown;
    private bool doSpawning = true;

    public List<GameObject> waves;

    void Start()
    {
        StartCoroutine(Spawning());
    }

    public void ToggleWaves()
    {
        doSpawning = !doSpawning;
        if (doSpawning)
        {
            StartCoroutine(Spawning());
        }
    }

    IEnumerator Spawning()
    {
        int prevWave = 0;
        int rng1 = 0;
        yield return new WaitForSeconds(loadInGracePeriod);
        while (doSpawning)
        {
            while (rng1 == prevWave)
            {
                rng1 = Random.Range(0, waves.Count);
            }

            prevWave = rng1;
            GameObject wave = Instantiate(waves[rng1]);
            //WaveInfo waveInfo = wave.GetComponent<WaveInfo>();
            float waveLenght = wave.GetComponent<WaveInfo>().waveLenght;
            Destroy(wave, waveLenght);

            yield return new WaitForSeconds(waveCooldown + waveLenght);
        }
    }
}
