using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    private bool isAlive;

    void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        isAlive = false;
        // code related to killing the entity, remove this function is it is deemed unnecessary
    }
}
