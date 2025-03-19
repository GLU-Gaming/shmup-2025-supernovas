using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody rb;
    private int Topscreen = 8;
    private int Bottemscreen = -6;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    { 
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(new Vector2(1, 0)); 
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
           rb.AddForce(new Vector2(-1, 0));
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(new Vector2(0, 1));
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(new Vector2(0, -1));
        }
        if (Player.transform.position.y > Topscreen) 
        {
            transform.position = Vector3.zero;
        }
        if (Player.transform.position.y == Bottemscreen)
        {
            transform.position = Vector3.zero;
        }
    }
}
