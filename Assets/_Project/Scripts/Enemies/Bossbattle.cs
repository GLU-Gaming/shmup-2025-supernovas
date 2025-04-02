using System.Collections;
using UnityEngine;

public class Bossbattle : EnemyBase
{
    [SerializeField] private float Speed;
    [SerializeField] public GameObject projectile;
    [SerializeField] public GameObject Enemy;
    public int height;
    void Start()
    {
        StartCoroutine(Spawning());
    }
    void Update()
    {
        transform.position = new Vector3(pos.x, pos.y + Mathf.Sin(Time.time) * 4, 0);
    }
    IEnumerator Spawning()
    {
        while (true)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(projectile,firePoint);
            }
            yield return new WaitForSeconds(10f);
            Instantiate(Enemy, firePoint);
        }
    }
}
