using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleIntensity : MonoBehaviour
{
   Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //light.intensity = Random.Range(1f, 4f);
        light.intensity =  5 + (Mathf.PerlinNoise(Time.time, 0f));
    }
}
