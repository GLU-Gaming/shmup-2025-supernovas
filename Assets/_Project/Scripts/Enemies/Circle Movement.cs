using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class CircleMovement : MonoBehaviour
{
    Vector3 pos;
    public CreationService creationService;
    private Bossbattle bossbattle;
    [SerializeField] private Transform firePoint;
    public Transform Player;
    public Transform Target;
    public float speedtarget = 1f;
    public float radius = 2f;
    public float angle;
    void Start()
    {
        bossbattle = FindAnyObjectByType<Bossbattle>();
        pos = transform.position;
        Startshoot();
    }

    void Update()
    {
        if (bossbattle.spinny > 0)
        {
            transform.position = new Vector3(pos.x, pos.y + Mathf.Sin(Time.time) * 4, 0);
        }
    }
    public void Startshoot()
    {
        if (bossbattle.spinny > 0)
        {
            StartCoroutine(ShootingTime());
        }
    }
    IEnumerator ShootingTime()
    {
        while (true)
        {
               
                yield return new WaitForSeconds(0.4f);
                creationService.CreateProjectile(0, firePoint);
        }
    }
}
