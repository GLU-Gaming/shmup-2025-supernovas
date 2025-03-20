using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
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
    }
}
