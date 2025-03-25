using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private CreationService creationService;
    [SerializeField] private int enemyIndex;

    void Awake()
    {
        creationService = GameObject.FindAnyObjectByType<CreationService>();
    }

    void OnTriggerEnter(Collider other)
    {
        creationService.CreateEnemy(enemyIndex, transform);
        Destroy(gameObject);
    }
}
