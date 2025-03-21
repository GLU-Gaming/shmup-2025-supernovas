using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] private float speed = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float lifespan = 10f;
    [SerializeField] private int piercing = 0; // 0 = infinite piercing, 1 = 1 piercing, 2,3,... = 2,3,... piercing
    private int validHits;
    private float startTime;
    private List<GameObject> targetsHit;

    public virtual void Start()
    {
        startTime = Time.time;
    }

    public virtual void Awake()
    {
        targetsHit = new List<GameObject>();
        validHits = 0;
    }

    public virtual void FixedUpdate()
    {
        transform.position += direction * speed;
    }

    private void Update()
    {
        // kill the projectile if it has exceeded its lifespan so they cant exist forever
        if (Time.time > startTime + lifespan)
        {
            Kill();
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        GameObject hit = other.gameObject;
        // check if the target hasnt already been hit
        if (targetsHit.Contains(hit)) { return; }
        targetsHit.Add(hit);
        // check if the target has health, projectile wont be able to hit things it shouldnt so checking for that is unnecessary
        hit.TryGetComponent<Health>(out Health hitHP);
        if (!hitHP) { return; }
        hitHP.TakeDamage(damage);

        // increment valid hits and kill the projectile if it cant pierce more.
        validHits ++;
        if (!(piercing == 0 || validHits < piercing)) {Kill();}
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
    }
}
