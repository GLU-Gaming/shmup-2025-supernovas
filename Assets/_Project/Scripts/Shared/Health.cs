using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void EventHandler();
    public event EventHandler EntityDied;
    public event EventHandler EntityDamaged;
    public int maxHealth;
    public int currentHealth;
    public bool isAlive = true;

    void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        EntityDamaged?.Invoke();
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        isAlive = false;
        EntityDied?.Invoke();
    }
}
