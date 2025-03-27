using UnityEngine;

public class ProjectileE : ProjectileBase
{
    [SerializeField] private float scaleUpBy;
    [SerializeField] private float scaleUpIn;
    private Vector3 fullScale;

    public override void Awake()
    {
        base.Awake();
        transform.localScale = Vector3.zero;
        fullScale = new Vector3(1, 1, 1) * scaleUpBy;
    }
    public override void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(Vector3.zero, fullScale, (Time.time - startTime) / scaleUpIn);
    }
}
