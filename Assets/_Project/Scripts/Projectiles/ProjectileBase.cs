using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;
    private float speed = 1;
    private float lifespan = 10f;
    private float startTime;


    private void Start()
    {
        startTime = Time.time;
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

    public void Kill()
    {
        Destroy(gameObject);
    }
}
