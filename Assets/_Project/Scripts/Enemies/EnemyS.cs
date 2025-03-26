using System.Collections;
using UnityEngine;

public class EnemyS : EnemyBase
{
    public Transform Hitpoint;
    [SerializeField] private CreationService creationService;
    [SerializeField] public float Speed;


    void Start()
    {
        creationService = FindAnyObjectByType<CreationService>();
        StartCoroutine(MyCoroutine());
    }
    private void FixedUpdate()
    {
        pos.x -= Speed;
    }
    void Update()
    {
        transform.position = new Vector3(pos.x, pos.y + Mathf.Sin(Time.time) *2, 0);
        if (pos.x < 0)
        {
           
        }
    }
    IEnumerator MyCoroutine()
    {
        while (true)
        {
            creationService.CreateProjectile(1, Hitpoint);
            yield return new WaitForSeconds(2);
        }
    }
}
