using System.Collections;
using UnityEngine;

public class EnemyA : EnemyBase
{
    public Transform Hitpoint;
    [SerializeField] private CreationService creationService;
    [SerializeField] private float Speed;
    [SerializeField] private GameObject RotationPart;
    [SerializeField] private float RotationSpeed = 3;

    void Start()
    {
        creationService = FindAnyObjectByType<CreationService>();
        StartCoroutine(MyCoroutine());
    }
    private void FixedUpdate()
    {
        pos.x -= Speed;
        RotationPart.transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 1) * RotationSpeed * (0.5f * Mathf.Cos(Time.time) + 0.75f));
    }
    void Update()
    {
        transform.position = new Vector3(pos.x, pos.y + Mathf.Sin(Time.time) * 4, 0);
    }
    IEnumerator MyCoroutine()
    {
        while (true)
        {
            creationService.CreateProjectile(0, Hitpoint);
            yield return new WaitForSeconds(2);
        }
    }
}
