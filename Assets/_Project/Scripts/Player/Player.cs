using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Vector3 playerSize;
    private CreationService creationService;
    public float attackCooldown = 0.2f;
    private float lastAttack = 0;
    InputAction moveAction;
    InputAction attackAction;
    Vector3 maxPos;
    Vector3 minPos;


    void Awake()
    {
        creationService = FindAnyObjectByType<CreationService>();
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Jump");

        Vector3 boundry = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.transform.position.y));
        Vector3 boundryOffset = Camera.main.transform.position;
        Vector3 boundryZero = boundry - boundryOffset;
        maxPos = boundryZero + boundryOffset - playerSize;
        minPos = -boundryZero + boundryOffset + playerSize;
    }


    void FixedUpdate()
    {
        if (Time.timeScale == 0) return;

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        moveValue = 0.08f * speed * moveValue.normalized;

        Vector3 newPos = transform.position + new Vector3(moveValue.x, moveValue.y);

        newPos.x = Mathf.Clamp(newPos.x, minPos.x, maxPos.x);
        newPos.y = Mathf.Clamp(newPos.y, minPos.y, maxPos.y);

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
