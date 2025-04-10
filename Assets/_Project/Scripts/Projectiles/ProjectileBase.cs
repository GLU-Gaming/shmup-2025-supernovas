using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] protected float speed = 1;
    [SerializeField] protected int damage = 1;
    [SerializeField] protected float lifespan = 10f;
    [SerializeField] protected int piercing = 0; // 0 = infinite piercing, 1 = 1 piercing, 2,3,... = 2,3,... piercing
    [SerializeField] protected float hitboxActiveAfter;
    [SerializeField] protected float hitboxActiveFor;
    protected int validHits;
    protected float startTime;
    protected List<GameObject> targetsHit;
    protected Collider elHitbox;

    public virtual void Start()
    {
        startTime = Time.time;
        StartCoroutine(Hitbox());
    }

    IEnumerator Hitbox()
    {
        yield return new WaitForSeconds(hitboxActiveAfter);
        elHitbox.enabled = true;
        if (hitboxActiveFor > 0)
        {
            yield return new WaitForSeconds(hitboxActiveFor);
            elHitbox.enabled = false;
        }
    }

    public virtual void Awake()
    {
        targetsHit = new List<GameObject>();
        elHitbox = GetComponent<Collider>();
        elHitbox.enabled = false;
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
            CleanUp();
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        GameObject hit = other.gameObject;
        // check if the target hasnt already been hit and that multiple enemies arent being hit at once
        if (targetsHit.Contains(hit) || (validHits >= piercing && piercing != 0)) { return; }
        targetsHit.Add(hit);
        // check if the target has health, projectile wont be able to hit things it shouldnt so checking for that is unnecessary
        hit.TryGetComponent<Health>(out Health hitHP);
        if (!hitHP) { return; }
        bool h = hitHP.TakeDamage(damage);
        if (!h) {return;}
        // increment valid hits and kill the projectile if it cant pierce more.
        validHits++;
        if (!(piercing == 0 || validHits < piercing)) { Kill(); }
    }

    public virtual void Kill()
    {
        CleanUp();
    }

    public void CleanUp()
    {
        Destroy(gameObject);
    }
}
