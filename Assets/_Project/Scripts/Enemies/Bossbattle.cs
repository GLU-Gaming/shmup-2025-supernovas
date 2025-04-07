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
        float Duration = 5f;
        int y = 2;
        while (Update < 1)
        {
            Update = (Time.time - Starttime) / Duration;
            transform.position = Vector3.Lerp(Startpos, Endpos,Update);
            yield return new WaitForEndOfFrame();
        }
        target.position = new Vector3(-7, 4, 0);
        transform.position = Vector3.Lerp(Endpos, Startpos, Update);
        spinnyDeathAttack();
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
