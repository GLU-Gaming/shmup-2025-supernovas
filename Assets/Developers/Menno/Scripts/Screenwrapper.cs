using UnityEngine;

public class Screenwrapper : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Camera mainCamera;

    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }
    void Update()
    {
        Vector3 newPosition = transform.position;

        Vector3 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.y));
        Vector3 topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.y));

        float leftBound = bottomLeft.x;
        float rightBound = topRight.x;
        float bottomBound = bottomLeft.y;
        float topBound = topRight.y;

        if (newPosition.x < leftBound && objectRigidbody.linearVelocity.x < 0)
        {
            newPosition.x = rightBound;
        }
        else if (newPosition.x > rightBound && objectRigidbody.linearVelocity.x > 0)
        {
            newPosition.x = leftBound;
        }

        if (newPosition.y < bottomBound && objectRigidbody.linearVelocity.z < 0)
        {
            newPosition.y = topBound;
        }
        else if (newPosition.z > topBound && objectRigidbody.linearVelocity.z > 0)
        {
            newPosition.y = bottomBound;
        }

        transform.position = newPosition;
    }
}
