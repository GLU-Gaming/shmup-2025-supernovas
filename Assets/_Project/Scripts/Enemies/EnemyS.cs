using System.Collections;
using UnityEngine;

public class EnemyS : EnemyBase
{
    [SerializeField] private Transform Firepoint;
    private CreationService creationService;


    // dive anim parameters:
    [SerializeField] float speed;
    [SerializeField] float lenght;
    [SerializeField] float depth;
    [SerializeField] float rOffset;
    [SerializeField] float rMult;

    void Start()
    {
        creationService = FindAnyObjectByType<CreationService>();
        StartCoroutine(MyCoroutine());
    }
    private void FixedUpdate()
    {

    }

    void Update()
    {
        float scaledT = Time.time * speed;
        float x = Mathf.Cos(scaledT);
        float y = -Mathf.Abs(Mathf.Sin(scaledT));
        float r = x * rMult + rOffset;

        transform.SetPositionAndRotation(pos + new Vector3(x * lenght, y * depth, 0), Quaternion.AngleAxis(r, Vector3.forward));
    }

    IEnumerator MyCoroutine()
    {
        while (true)
        {
            creationService.CreateProjectile(0, Firepoint);
            yield return new WaitForSeconds(2);
        }
    }
}
