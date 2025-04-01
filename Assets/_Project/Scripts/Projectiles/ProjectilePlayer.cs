using UnityEngine;

public class ProjectilePlayer : ProjectileBase
{
    public override void FixedUpdate()
    {
        transform.position += transform.forward * speed;
        transform.rotation *= Quaternion.AngleAxis(0.15f, Vector3.right);
    }
}
