using UnityEngine;
using UnityEngine.UI;

public class Incoming : MonoBehaviour
{

    [SerializeField] private Image incomingUI;

    void Awake()
    {
        incomingUI.gameObject.SetActive(false);
    }

    public void Warn(Vector3 position)
    {
        incomingUI.transform.position = Camera.main.WorldToScreenPoint(position);
        //incomingUI.rectTransform.SetLocalPositionAndRotation(Camera.main.WorldToScreenPoint(position),Quaternion.identity);
        incomingUI.gameObject.SetActive(true);
    }

}
