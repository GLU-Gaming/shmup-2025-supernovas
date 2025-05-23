using UnityEngine;

public class CirkelMovement : MonoBehaviour
{
    public Transform Target;
    public float speedtarget = 1f;
    public float radius = 2f;
    public float angle;
    void Start()
    {
    }

    void Update()
    {
        float x = Target.position.x + Mathf.Cos(angle) * radius;
        float y = Target.position.y + Mathf.Sin(angle) * radius;
        float z = Target.position.z;
        transform.position = new Vector3(x, y, z);
        angle += speedtarget * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage(1);
        }
    }

}
