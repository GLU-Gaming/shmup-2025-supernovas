using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class CircleMovement : MonoBehaviour
{
    public CreationService creationService;
    [SerializeField] private Transform firePoint;
    public Transform Player;
    public Transform Target;
    public float speedtarget = 1f;
    public float radius = 2f;
    public float angle;
    void Start()
    {
        StartCoroutine(ShootingTime());
    }

    void Update()
    {
        
    }
    IEnumerator ShootingTime()
    {
        while (true)
        {
               
                yield return new WaitForSeconds(0.4f);
                creationService.CreateProjectile(1, firePoint);
        }
    }
}
