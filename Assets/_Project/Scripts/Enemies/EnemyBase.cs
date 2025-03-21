using System.Threading;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float DownMovTim;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Movement();
    }
    private void Update()
    {
        DownMovTim += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        Movement();
        if (DownMovTim >= 10)
        {
            DownMovTim = 0;
            Movement();
        }
    }
    public void Movement()
    {
        if (DownMovTim < 2)
        {
          rb.AddForce(new Vector3(0,1,0));
        }   
        else 
        {
            rb.AddForce(new Vector3(0, -1, 0));
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
