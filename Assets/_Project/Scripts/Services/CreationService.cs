using System.Collections.Generic;
using UnityEngine;

public class CreationService : MonoBehaviour
{

    // Attach to the "Services" GameObject.
    // Collection of various instatiate related functions.
    // Used as a cleaner way of instantiating Prefabs that require more parameters than just position and rotation
    // as well as gathering Prefabs in one place.

    public List<GameObject> projectiles;
    public List<GameObject> enemies;

    public void CreateProjectile(int index, Transform transform)
    {
        Vector3 direction = transform.rotation * Vector3.forward;
        GameObject projectile = Instantiate(projectiles[index], transform.position, transform.rotation);
        projectile.GetComponent<ProjectileBase>().direction = direction;
    }

    public void CreateEnemy(int index, Transform transform)
    {
        GameObject enemy = Instantiate(enemies[index], transform.position, transform.rotation);
    }
}
