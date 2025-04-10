using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public CreationService creationService;
    public Health health;
    private ProjectileBoss projectileboss;
    [SerializeField] private Transform firePoint;
    public GameObject Win;
    public GameObject Projectile;
    public GameObject Enemy;
    public GameObject HoldUp;
    public GameObject Player;
    public GameObject Pos;
    public GameObject Pos2;
    [SerializeField] public int amountEnemy;
    private Vector3 pos;
    public int Attack2;

    void Awake()
    {
        Player = FindAnyObjectByType<Player>().gameObject;
    }
    void Start()
    {
        health = GetComponent<Health>();
        projectileboss = FindAnyObjectByType<ProjectileBoss>();
        pos = transform.position;
        HoldUp.SetActive(false);
    }

    void Update()
    {
        health.EntityDied += Victory;
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
            Pos2.transform.position = new Vector3(7, 3, 0);
            projectileboss.spinny = 0;
            StartCoroutine(MoveScreen());
            StartCoroutine(StartspinnyAgian());
        }
        //        IEnumerator ShootingTime()
        //        {
        //            while (true)
        //            {
        //                yield return new WaitForSeconds(3f);
        //                creationService.CreateProjectile(0, firePoint);
        //                if (projectileboss.spinny > 0)
        //                {
        //                    StartCoroutine(CreatingEnemy());
        //                }
        //            }
        //        }
        //        IEnumerator CreatingEnemy()
        //        {
        //            yield return new WaitForSeconds(2f);
        //            Instantiate(Enemy, firePoint.transform.position, Quaternion.identity);
        //        }
    }
    IEnumerator MoveScreen()
    {
        yield return new WaitForSeconds(5f);
        Pos2.transform.position = new Vector3(-8, -3, 0);
    }
    IEnumerator AttackAir()
    {
        yield return new WaitForSeconds(15f);
        Attack2 = 1;
    }
    IEnumerator StartspinnyAgian()
    {
        yield return new WaitForSeconds(15f);
        Attack2 = 0;
        HoldUp.SetActive(true);
        projectileboss.Spinnystart();
    }
    public void Victory()
    {
        Win.SetActive(true);
        Destroy(gameObject);
        Destroy(Player);
        HoldUp.SetActive(false);
    }
}
