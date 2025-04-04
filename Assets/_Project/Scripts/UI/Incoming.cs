using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Incoming : MonoBehaviour
{

    [SerializeField] private Image incomingUI;
    [SerializeField] private float warnTime;

    void Awake()
    {
        incomingUI.gameObject.SetActive(false);
    }

    public WaitForSeconds Warn(Vector3 position)
    {
        if (position.y > 5f) // i dont like this but it works 
        {
            StartCoroutine(WarnAnim(new Vector3(0,7,0)));
        }
        else
        {
            StartCoroutine(WarnAnim(new Vector3(0,-5,0)));
        }

        return new WaitForSeconds(warnTime);
    }

    IEnumerator WarnAnim(Vector3 pos)
    {
        incomingUI.transform.position = Camera.main.WorldToScreenPoint(pos);
        incomingUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(warnTime);
        incomingUI.gameObject.SetActive(false);
    }

}
