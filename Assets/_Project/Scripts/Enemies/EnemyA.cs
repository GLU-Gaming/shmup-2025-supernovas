using System.Collections;
using UnityEngine;

public class EnemyA : EnemyBase
{
    public Transform Hitpoint;
    [SerializeField] private CreationService creationService;
    [SerializeField] public float Speed;

    void Start()
    {
        StartCoroutine(MyCoroutine());
    }
    private void FixedUpdate()
    {
        pos.x -= Speed;
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
