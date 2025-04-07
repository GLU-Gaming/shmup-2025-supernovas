using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class CircleMovement : MonoBehaviour
{
    public CreationService creationService;
    private Bossbattle bossbattle;
    [SerializeField] private Transform firePoint;
    public Transform Target;
    public GameObject Projectile;
    public GameObject Enemy;
    [SerializeField] public int amountEnemy;
    private Vector3 pos;
    void Start()
    {
        bossbattle = FindAnyObjectByType<Bossbattle>();
        pos = transform.position;
        StartCoroutine(ShootingTime());
    }

    void Update()
    {
        if (bossbattle.spinny > 0)
        {
            transform.position = new Vector3(pos.x, pos.y + Mathf.Sin(Time.time) * 4, 0);
            Projectile.SetActive(false);
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
               if (bossbattle.spinny > 0)
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
