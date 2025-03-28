using UnityEngine;

public class ProjectileE : ProjectileBase
{
    [SerializeField] private Vector3 scaleStart;
    [SerializeField] private Vector3 scaleUpBy;
    [SerializeField] private float scaleUpIn;
    private Vector3 fullScale;

    public override void Awake()
    {
        base.Awake();
        transform.localScale = Vector3.zero;
        fullScale = scaleStart + scaleUpBy;
    }
    public override void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(Vector3.zero, fullScale, (Time.time - startTime) / scaleUpIn);
    }
}
