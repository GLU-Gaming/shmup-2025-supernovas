using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] private float speed = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float lifespan = 10f;
    [SerializeField] private int piercing = 0; // 0 = infinite piercing, 1 = 1 piercing, 2,3,... = 2,3,... piercing
    //private int totalHits;
    private float startTime;
    private List<GameObject> targetsHit;

    private void Start()
    {
        startTime = Time.time;
    }

    void Awake()
    {
        targetsHit = new List<GameObject>();
        //totalHits = 0;
    }

    private void FixedUpdate()
    {
        transform.position += direction * speed;
    }

    private void Update()
    {
        if (Time.time > startTime + lifespan)
        {
            Kill();
        }
    }

    void OnTriggerEnter(Collider other)
    {

        GameObject hit = other.gameObject;
        if (targetsHit.Contains(hit)) { return; }
        targetsHit.Add(hit);
        hit.TryGetComponent<Health>(out Health hitHP);
        if (!hitHP) { return; }
        hitHP.TakeDamage(damage);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
