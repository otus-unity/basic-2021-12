using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public float Delay = 1.0f;
    float TimeLeft;

    void Start()
    {
        TimeLeft = Delay;
    }

    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0.0f) {
            TimeLeft = Delay;
            Instantiate(Prefab, transform.position, transform.rotation);
        }
    }
}
