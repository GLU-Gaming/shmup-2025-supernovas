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
       // float x = Target.position.x + Mathf.Cos(angle) * radius;
       // float y = Target.position.y + Mathf.Sin(angle) * radius;
       // float z = Target.position.z;
       // transform.position = new Vector3(x, y, z);
       // angle += speedtarget * Time.deltaTime;
        float angletp = Vector3.Angle(transform.position, Player.transform.position);
        transform.rotation = Quaternion.AngleAxis(angletp, Vector3.left);
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
