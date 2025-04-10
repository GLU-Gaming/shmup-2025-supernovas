using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int index;
    public float spawnTime;
    public int repeat;
    public float repeatTime;

    private CreationService creationService;

    void Awake()
    {
        creationService = GameObject.FindAnyObjectByType<CreationService>();
    }

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnTime);
        while (repeat + 1 > 0)
        {
            creationService.CreateEnemy(index,transform);
            yield return new WaitForSeconds(repeatTime);
            repeat --;
        }
    }
}