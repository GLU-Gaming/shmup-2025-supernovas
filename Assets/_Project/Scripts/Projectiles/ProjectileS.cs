using UnityEngine;

public class ProjectileS : ProjectileBase
{
    public override void FixedUpdate()
    {
        if (Time.time > startTime)
        {
            speed = 0.4f;
            
        }
        base.FixedUpdate();
    }
}
