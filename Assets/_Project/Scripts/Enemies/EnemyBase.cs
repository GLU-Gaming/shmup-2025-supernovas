using UnityEngine;

public class EnemyBase : MonoBehaviour
{
public float HP;

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
