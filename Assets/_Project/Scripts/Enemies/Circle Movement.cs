using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class CircleMovement : MonoBehaviour
{
    public CreationService creationService;
    private ProjectileBoss projectileboss;
    [SerializeField] private Transform firePoint;
    public Transform Target;
    public GameObject Projectile;
    public GameObject Enemy;
    public GameObject HoldUp;
    public GameObject Player;
    public GameObject Pos;
    [SerializeField] public int amountEnemy;
    private Vector3 pos;
    void Start()
    {
        projectileboss = FindAnyObjectByType<ProjectileBoss>();
        pos = transform.position;
        StartCoroutine(ShootingTime());
        StartCoroutine(startSpinny());
        HoldUp.SetActive(false);
    }

    void Update()
    {
        float speed = 0.03f;
        if (projectileboss.spinny > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);
            Projectile.SetActive(false);
            HoldUp.SetActive(true);
        }
    }
    private void UpdateEnemy()
    {
        StartCoroutine(CreatingEnemy());
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
    IEnumerator startSpinny()
    {
        yield return new WaitForSeconds(17f);
        StartCoroutine(StartSpinnyAgain());
    }
    IEnumerator StartSpinnyAgain()
    {
        yield return new WaitForSeconds(1f);
        Projectile.SetActive(true);
        HoldUp.SetActive(false);
        transform.position = new Vector3(6,1,1);
        Pos.transform.position = new Vector3(-7,5,0);
        projectileboss.spinnyDeathAttack();
    }
}
