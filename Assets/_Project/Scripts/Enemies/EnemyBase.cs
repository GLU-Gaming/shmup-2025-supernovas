using System;
using System.Collections;
using System.Threading;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Vector3 pos;
    private void Awake()
    {
        pos = transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
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
