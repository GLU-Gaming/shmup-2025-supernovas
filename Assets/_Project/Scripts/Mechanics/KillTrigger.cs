using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    [SerializeField] private bool despawn;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyBase>(out EnemyBase c))
        {
            if (despawn) c.CleanUp(); else c.Death();
        }
    }
}
