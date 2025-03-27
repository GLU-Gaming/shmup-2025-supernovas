using System.Collections;
using UnityEngine;

public class EnemyS : EnemyBase
{
    [SerializeField] private Transform Firepoint;
    [SerializeField] private GameObject rotationPart;
    private CreationService creationService;


    // dive anim parameters:
    [SerializeField] float speed;
    [SerializeField] float lenght;
    [SerializeField] float depth;
    [SerializeField] float rOffset;
    [SerializeField] float rMult;

    void Start()
    {
        creationService = FindAnyObjectByType<CreationService>();
    }

    public IEnumerator DiveAnim()
    {
        float startT = Time.time;
        float localT = 0f;

        while (Time.time < startT + 1/speed*Mathf.PI)
        {
            float scaledT = localT * speed;
            float x = Mathf.Cos(scaledT);
            float y = -Mathf.Abs(Mathf.Sin(scaledT));
            float r = x * rMult + rOffset;
            rotationPart.transform.SetPositionAndRotation(pos + new Vector3(x * lenght, y * depth, 0), Quaternion.AngleAxis(r, Vector3.forward));
            localT += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
