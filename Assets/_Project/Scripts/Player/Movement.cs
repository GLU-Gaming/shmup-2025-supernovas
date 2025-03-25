using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject DeathMenuUI;
    [SerializeField] private float speed = 1;
    [SerializeField] private CreationService creationService;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Health health;
    public float attackCooldown = 0.2f;
    private float lastAttack;

    InputAction moveAction;
    InputAction attackAction;



    void Start()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody>();
        DeathMenuUI.SetActive(false);
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
    private void OnTriggerEnter(Collider other)
    {
        if (health.currentHealth == 0)
        {
            Destroy(gameObject);
            DeathMenuUI.SetActive(true);
        }
    }
}
