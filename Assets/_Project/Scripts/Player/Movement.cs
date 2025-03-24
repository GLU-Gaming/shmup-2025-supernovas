using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float speed = 1;
    [SerializeField] private CreationService creationService;
    [SerializeField] private Transform firePoint;
    public float attackCooldown = 0.2f;
    private float lastAttack;

    InputAction moveAction;
    InputAction attackAction;



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

        if (Time.timeScale == 0) return;
        transform.position += new Vector3(moveValue.x * speed * 0.08f, moveValue.y * speed * 0.08f);

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
