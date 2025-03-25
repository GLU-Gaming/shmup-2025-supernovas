using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Transform> SpawnPositions;
    [SerializeField] private CreationService creationService;

    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        int enemiesToSpawn = 1;
        while (true)
        {

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                creationService.CreateEnemy(0, SpawnPositions[Random.Range(0, SpawnPositions.Count)]);
            }

            yield return new WaitForSeconds(1f);
        }
    }

}
