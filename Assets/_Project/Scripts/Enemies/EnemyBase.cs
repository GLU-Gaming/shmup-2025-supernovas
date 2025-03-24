using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Enemy;
    public Vector3 pos;
    private float BulletSpeed = 12.0f;
    private void Awake()
    {
        pos = transform.position;
    }
    public void Start()
    {
        GameObject bulletObj = Instantiate(Bullet,Enemy.transform, Enemy.transform);
    }
    private void Update()
    {
        transform.position = new Vector3(pos.x, pos.y + Mathf.Sin(Time.time) * 4, 0);
         
    }
    public void Death()
    {
        // add death effects, player score, possibly spawn a powerup

        CleanUp();
    }

    public void CleanUp()
    {
        Destroy(gameObject);
    }

}
