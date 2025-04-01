using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyBase : MonoBehaviour
{
    protected Vector3 pos;
    protected Health health;
    protected CreationService creationService;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected int scoreamount;
    protected Score score;
    protected GameObject player;  

    protected virtual void Awake()
    {
        pos = transform.position;
        creationService = FindAnyObjectByType<CreationService>();
        health = GetComponent<Health>();
        player = FindAnyObjectByType<Player>().gameObject;
        score = FindAnyObjectByType<Score>();

        // subscribe to death event from the health script
        health.EntityDied += Death;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            CleanUp();
        }
    }

    // ENEMY IS KILL!!!!!
    public virtual void Death()
    {
        // add death effects, player score, possibly spawn a powerup  
        score.UiUpdate(scoreamount);
        CleanUp();
    }

    // Destroy the gameObject without triggering death effects
    public void CleanUp()
    {
        Destroy(gameObject);
    }
}
