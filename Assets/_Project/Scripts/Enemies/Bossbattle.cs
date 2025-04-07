using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class Bossbattle : EnemyBase
{
    public Transform target;
    public GameObject Enemy;
    [SerializeField] public int amountEnemy;
    public float speed;
    public int y = 2;

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

        float Update = 0;
        float Starttime = Time.time;
        float Duration = 3f;

        while (Update < 1)
        {
            Update = (Time.time - Starttime) / Duration;
            transform.position = Vector3.Lerp(Startpos, Endpos,Update);
            yield return new WaitForEndOfFrame();
        }
        target.position = new Vector3(-7, 4 - y, 0);
        y = y + 2;
        transform.position = Vector3.Lerp(Endpos, Startpos, Update);
        if (y < 10)
        {
            spinnyDeathAttack();
        }
        else 
        {
            CreateEnemy();
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
