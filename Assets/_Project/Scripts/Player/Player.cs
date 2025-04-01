using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Vector2 Size;
    private CreationService creationService;
    public float attackCooldown = 0.2f;
    private float lastAttack = 0;
    Vector3 boundry;
    InputAction moveAction;
    InputAction attackAction;

    void Awake()
    {
        creationService = FindAnyObjectByType<CreationService>();
        boundry = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.transform.position.y));
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Jump");
    }

    void FixedUpdate()
    {
        if (Time.timeScale == 0) return;

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        moveValue = 0.08f * speed * moveValue.normalized;

        Vector3 newPos = transform.position + new Vector3(moveValue.x, moveValue.y);
        newPos.x = Mathf.Clamp(newPos.x, -boundry.x + Size.x * 0.5f, boundry.x - Size.x * 0.5f);
        newPos.y = Mathf.Clamp(newPos.y, -boundry.y + Size.y * 0.5f, boundry.y - Size.y * 0.5f);

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
