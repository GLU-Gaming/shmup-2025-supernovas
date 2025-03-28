using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Transform> SpawnPositions;
    public List<Transform> S_SpawnPositions;
    [SerializeField] private CreationService creationService;

    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        int enemiesToSpawn = 5;

        while (true)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                int rng1 = Random.Range(0, creationService.enemies.Count);
                int rng2 = Random.Range(0, SpawnPositions.Count);
                int rng3 = Random.Range(0, S_SpawnPositions.Count);
                if (rng1 == 2)
                {
                    creationService.CreateEnemy(rng1, S_SpawnPositions[rng3]);
                }
                else
                {
                    creationService.CreateEnemy(rng1, SpawnPositions[rng2]);
                }
            }


            yield return new WaitForSeconds(4f);
        }
    }

}
