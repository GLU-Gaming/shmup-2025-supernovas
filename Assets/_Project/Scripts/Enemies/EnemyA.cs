using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemyA : MonoBehaviour
{
    public Vector3 pos;
    public GameObject Bullet;
    public Transform Hitpoint;
    [SerializeField] private CreationService creationService;
    [SerializeField] public float Speed;

    void Start()
    {
        StartCoroutine(MyCoroutine());
    }
    private void FixedUpdate()
    {
        pos.x -= Speed;
    }
    void Update()
    {
        transform.position = new Vector3(pos.x, pos.y + Mathf.Sin(Time.time) * 4, 0);
    }
    IEnumerator MyCoroutine()
    {
        while (true)
        {
            creationService.CreateProjectile(0, Hitpoint);
            yield return new WaitForSeconds(2);
        }
    }
}
