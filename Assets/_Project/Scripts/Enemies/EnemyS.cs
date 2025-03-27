using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class EnemyS : MonoBehaviour
{
    public Transform Circeltarget;
    public Transform Hitpoint;
    [SerializeField] private CreationService creationService;
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float Radius = 5f;
    [SerializeField] private float Angle = 5f;

    float tiltAngle = 60.0f;
    Quaternion target;
    void Start()
    {
        creationService = FindAnyObjectByType<CreationService>();
        StartCoroutine(MyCoroutine());
    }
    private void FixedUpdate()
    {
      
    }
    void Update()
    {

        float x = Circeltarget.position.x + Mathf.Cos(Angle)* Radius;
        float y = Circeltarget.position.y - Mathf.Abs(Mathf.Sin(Angle)) * Radius;  
        float z = Circeltarget.position.z;

        // Update the position of EnemyS
        transform.position = new Vector3(x, y, z);

        //increment the angle to move along the cricular path
        Angle += Speed * Time.deltaTime;
        if (transform.position.x >= 6)
        {
            // Rotate the cube by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(0, 0, 18);
            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
        }

        if (transform.position.y <= 2)
        {
            Quaternion target = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
        }
        if (transform.position.y >= 5)
        {
            Quaternion target = Quaternion.Euler(0, 0, -18);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
        }

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
