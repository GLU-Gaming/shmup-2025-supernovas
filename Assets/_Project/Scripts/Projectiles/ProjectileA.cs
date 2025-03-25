using UnityEngine;

public class ProjectileA : ProjectileBase
{

    [SerializeField] private float fallAfter = 1;

    public override void FixedUpdate()
    {
        if (Time.time > startTime + fallAfter)
        {
            speed = 0.08f;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            transform.rotation *= Quaternion.AngleAxis(3, Vector3.right);
        }
        base.FixedUpdate();
    }
}
