using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Health health;
    public ScreenShake shake;
    public Vector3 pos;
    private void Awake()
    {
        pos = transform.position;
    }
    private void Start()
    {
        health = GetComponent<Health>();    
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            CleanUp();
        }
        if (health.currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
    public void Death()
    {
        // add death effects, player score, possibly spawn a powerup
        CleanUp();
    }

    public void CleanUp()
    {
        Destroy(gameObject);
    }

}
