using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawning : MonoBehaviour
{

    public float loadInGracePeriod; // Time until anything actually happens
    public float waveCooldown;
    private bool doSpawning = true;
    public int totalWavesPassed = 0;
    public int wavesTillBoss;

    public List<GameObject> waves;
    public GameObject bossWave;

    void Start()
    {
        totalWavesPassed = 0;
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

    void BossWave()
    {
        GameObject wave = Instantiate(bossWave);
        float waveLenght = wave.GetComponent<WaveInfo>().waveLenght;
        Destroy(wave, waveLenght);
    }

    IEnumerator Spawning()
    {
        int prevWave = 0;
        int rng1 = 0;
        yield return new WaitForSeconds(loadInGracePeriod);
        while (doSpawning)
        {
            if (totalWavesPassed >= wavesTillBoss)
            {
                ToggleWaves();
                BossWave();
                yield break;
            }

            while (rng1 == prevWave)
            {
                rng1 = Random.Range(0, waves.Count);
            }

            prevWave = rng1;
            GameObject wave = Instantiate(waves[rng1]);
            //WaveInfo waveInfo = wave.GetComponent<WaveInfo>();
            float waveLenght = wave.GetComponent<WaveInfo>().waveLenght;
            Destroy(wave, waveLenght);
            totalWavesPassed++;
            yield return new WaitForSeconds(waveCooldown + waveLenght);
        }
    }
}
