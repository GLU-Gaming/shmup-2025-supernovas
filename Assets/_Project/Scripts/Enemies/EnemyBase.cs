using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Health health;
    public Vector3 pos;
    private void Awake()
    {
        pos = transform.position;
        health = GetComponent<Health>();
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
