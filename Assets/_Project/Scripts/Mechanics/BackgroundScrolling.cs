using System.Collections;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] public bool stop;
    [SerializeField] public float speed;
    [SerializeField] private Renderer m_RenderBuffer;
    public void Start()
    {
        stop = false;
        StartCoroutine(Stop());
    }
    void Update()
    {
       
    }
    IEnumerator Stop()
    {
        while (!stop)
        {
            m_RenderBuffer.material.mainTextureOffset -= new Vector2(speed * Time.deltaTime, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}
