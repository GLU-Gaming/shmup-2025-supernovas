using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Player.transform.position = Vector3.zero;
    }
}
