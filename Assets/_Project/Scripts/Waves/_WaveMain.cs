using System.Collections.Generic;
using UnityEngine;



public class WaveMain : MonoBehaviour
{

    private CreationService creationService;
    public List<GameObject> Waves;

    void Awake()
    {
        creationService = GameObject.FindAnyObjectByType<CreationService>();
    }

    void Start()
    {
    }
}
