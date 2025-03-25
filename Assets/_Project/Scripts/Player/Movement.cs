using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float speed = 1;
    [SerializeField] private CreationService creationService;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Vector2 Size;
    public float attackCooldown = 0.2f;
    private float lastAttack;
    Vector3 boundry;
    InputAction moveAction;
    InputAction attackAction;

    void Awake()
    {
        boundry = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.transform.position.y));
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Jump");

        lastAttack = Time.time;
    }

    void FixedUpdate()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        moveValue = 0.08f * speed * moveValue.normalized;

        if (Time.timeScale == 0) return;
        Vector3 newPos = transform.position + new Vector3(moveValue.x , moveValue.y);
        newPos.x = Mathf.Clamp(newPos.x,-boundry.x+Size.x*0.5f,boundry.x-Size.x*0.5f);
        newPos.y = Mathf.Clamp(newPos.y,-boundry.y+Size.y*0.5f,boundry.y-Size.y*0.5f);
        transform.position = newPos;
    }

    void Update()
    {
        if (Time.timeScale == 0) return;

        if (attackAction.IsPressed() && Time.time > lastAttack + attackCooldown)
        {
            lastAttack = Time.time;
            creationService.CreateProjectile(1, firePoint);
        }
    }
}
