using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Vector3 pos;
    public Health health;
    public CreationService creationService;
    public Transform firePoint;

    private void Awake()
    {
        pos = transform.position;
        creationService = FindAnyObjectByType<CreationService>();
        health = GetComponent<Health>();

        // subscribe to death event from the health script
        health.EntityDied += Death;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            CleanUp();
        }
    }

    // ENEMY IS KILL!!!!!
    public void Death()
    {
        // add death effects, player score, possibly spawn a powerup
        CleanUp();
    }

    // Destroy the gameObject without triggering death effects
    public void CleanUp()
    {
        Destroy(gameObject);
    }
}
