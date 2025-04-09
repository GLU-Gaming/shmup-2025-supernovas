using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public CreationService creationService;
    private ProjectileBoss projectileboss;
    [SerializeField] private Transform firePoint;
    public GameObject Projectile;
    public GameObject Enemy;
    public GameObject HoldUp;
    public GameObject Player;
    public GameObject Pos;
    public GameObject Pos2;
    [SerializeField] public int amountEnemy;
    private Vector3 pos;
    public int Attack2;
    bool AirAttack = false;
    void Start()
    {
        AirAttack = false;
        projectileboss = FindAnyObjectByType<ProjectileBoss>();
        pos = transform.position;
        StartCoroutine(ShootingTime());
        HoldUp.SetActive(false);
    }

    void Update()
    {
        float speed = 0.03f;
        if (projectileboss.spinny > 0)
        {
            HoldUp.SetActive(true);
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);
            Projectile.SetActive(false);
            StartCoroutine(AttackAir());
        }
        if (Attack2 > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Pos2.transform.position, speed);
            HoldUp.SetActive(false);
            projectileboss.spinny = 0;
            StartCoroutine(StartspinnyAgian());
        }
    }
    IEnumerator AttackAir()
    {
        yield return new WaitForSeconds(15f);
        Attack2 = 1;
    }
    IEnumerator StartspinnyAgian()
    {
        yield return new WaitForSeconds(5f);
        Attack2 = 0;
        HoldUp.SetActive(true);
        projectileboss.Spinnystart();
    }
    IEnumerator ShootingTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            creationService.CreateProjectile(0, firePoint);
            if (projectileboss.spinny > 0)
            {
                StartCoroutine(CreatingEnemy());
            }
        }
    }
    IEnumerator CreatingEnemy()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(Enemy, firePoint.transform.position, Quaternion.identity);
    }

}
