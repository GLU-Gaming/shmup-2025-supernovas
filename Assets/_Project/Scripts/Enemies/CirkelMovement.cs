using UnityEngine;

public class CirkelMovement : MonoBehaviour
{
    private Health health;
    public Transform Target;
    public float speedtarget = 1f;
    public float radius = 2f;
    public float angle;
    void Start()
    {
       health = FindAnyObjectByType<Health>();
    }

    void Update()
    {
        float x = Target.position.x + Mathf.Cos(angle) * radius;
        float y = Target.position.y + Mathf.Sin(angle) * radius;
        float z = Target.position.z;
        transform.position = new Vector3(x, y, z);
        angle += speedtarget * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        health.TakeDamage(1);
    }

}
