using UnityEngine;

public class ProjectileS : ProjectileBase
{
    public override void FixedUpdate()
    {
        if (Time.time > startTime)
        {
            speed = 0.4f;
            lifespan = 5f;
            damage = 2;
        }
        base.FixedUpdate();
    }
}
