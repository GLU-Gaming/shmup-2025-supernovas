using System.Collections;
using UnityEngine;

public class Bossbattle : EnemyBase
{
    public Transform target;
    public GameObject Enemy;
    [SerializeField] public int amountEnemy;
    public float speed;
    public bool hi;

    void Start()
    {
        spinnyDeathAttack();
        for (int i = 0; i < amountEnemy; i++)
        {
            CreateEnemy();
        }     
    }
    void Update()
    {
        
    }
    IEnumerator startSequence()
    {
        Vector3 Startpos = transform.position;
        Vector3 Endpos = target.position;
        if (hi == true)
        {
            Vector3 Startposi = target.position;
            Vector3 Endposi = transform.position;
        }
        float Update = 0;
        float Starttime = Time.time;
        float Duration = 3f;

        while (Update < 1)
        {
            Update = (Time.time - Starttime) / Duration;
            transform.position = Vector3.Lerp(Startpos, Endpos,Update);
            yield return new WaitForEndOfFrame();
        }
    }
    public void spinnyDeathAttack()
    {
        StartCoroutine(startSequence());
    }
    public void CreateEnemy()
    {
            Instantiate(Enemy, firePoint.transform.position, Quaternion.identity);
    }
}
