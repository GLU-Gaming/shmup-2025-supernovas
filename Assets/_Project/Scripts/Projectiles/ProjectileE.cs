using UnityEngine;

public class ProjectileE : ProjectileBase
{
    [SerializeField] private Vector3 scaleStart;
    [SerializeField] private Vector3 scaleUpTo;
    [SerializeField] private Vector3 scaleDownTo;
    [SerializeField] private float scaleUpIn;
    [SerializeField] private float scaleDownIn;
    [SerializeField] private float scaleDownAfter;

    private Vector3 scaleFull;


    public override void Awake()
    {
        base.Awake();
        transform.localScale = Vector3.zero;
        scaleFull = scaleStart + scaleUpTo;
    }
    public override void FixedUpdate()
    {
        if (Time.time >= startTime + scaleUpIn + scaleDownAfter)
        {
            transform.localScale = Vector3.Lerp(scaleFull, scaleDownTo, (Time.time - (startTime + scaleUpIn + scaleDownAfter)) / scaleDownIn);
            return;
        }
        transform.localScale = Vector3.Lerp(scaleStart, scaleFull, (Time.time - startTime) / scaleUpIn);
    }
}
