using System;
using System.Collections;
using System.Threading;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Vector3 pos;
    public GameObject Bullet;
    public Transform Hitpoint;
    [SerializeField] private CreationService creationService;

    private void Awake()
    {
        pos = transform.position;
    }
    public void Start()
    {
        StartCoroutine(MyCoroutine());
    }
    private void Update()
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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            Debug.Log("Hiiii");
            CleanUp();
        }
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
