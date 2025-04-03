using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void EventHandler();
    public event EventHandler EntityDied;
    public event EventHandler EntityDamaged;
    public int maxHealth;
    public int currentHealth;
    public bool isAlive = true;
    public float iFrames;
    public bool titlecard; // "invincible"

    void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
        titlecard = false;
    }

    IEnumerator Titlecard() // "Invincible"
    {
        titlecard = true;
        yield return new WaitForSeconds(iFrames);
        titlecard = false;
    }

    public bool TakeDamage(int amount)
    {
        if (titlecard) {return false;}
        currentHealth -= amount;
        StartCoroutine(Titlecard());
        EntityDamaged?.Invoke();
        if (currentHealth <= 0)
        {
            Death();
        }
        return true;
    }

    public void Death()
    {
        isAlive = false;
        EntityDied?.Invoke();
    }
}
