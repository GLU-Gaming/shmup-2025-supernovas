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

    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(loadInGracePeriod);
        while (doSpawning)
        {
            int rng1 = Random.Range(0,waves.Count);
            GameObject wave = Instantiate(waves[rng1]);
            //WaveInfo waveInfo = wave.GetComponent<WaveInfo>();
            float waveLenght = wave.GetComponent<WaveInfo>().waveLenght;
            Destroy(wave, waveLenght);
            
            yield return new WaitForSeconds(waveCooldown + waveLenght);
        }
    }
}
