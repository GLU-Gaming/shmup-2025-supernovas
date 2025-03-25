using UnityEngine;

public class ProjectilePlayer : ProjectileBase
{
    [SerializeField] private float fallAfter = 1;
    public override void FixedUpdate()
    {
        transform.position += transform.forward * speed;
        transform.rotation *= Quaternion.AngleAxis(0.15f, Vector3.right);
    }
}
