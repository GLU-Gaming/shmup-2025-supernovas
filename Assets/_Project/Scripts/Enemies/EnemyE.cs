using UnityEngine;

public class EnemyE : EnemyBase
{
    [SerializeField] float speed = 0.18f;
    [SerializeField] Transform rotationPart;
    void FixedUpdate()
    {

        //pos += Vector3.Cross(transform.forward, Vector3.up)*speed;
        float dP = player.transform.position.y - pos.y;
        pos.y = Mathf.Lerp(pos.y,pos.y+dP,0.05f);
        pos.x -= speed;

        rotationPart.transform.rotation = Quaternion.AngleAxis(dP*10,Vector3.back);
        //transform.rotation *= Quaternion.AngleAxis(dP,Vector3.forward);
    }

    void Update()
    {
        transform.position = pos;
    }
}
