using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light light0;
    public SphereCollider sphereCollider;
    public bool isLight;
    private void Awake()
    {
        light0=GetComponent<Light>();
        sphereCollider=GetComponent<SphereCollider>();
    }
    private void Update()
    {
        OnLight();
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Item>().OnLight = true;
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Item>().OnLight = false;
    }
    public void OnLight()
    {
        if (isLight) {
            light0.enabled = true;
            sphereCollider.radius = 4;
        }
        else
        {
            light0.enabled = false;
            sphereCollider.radius = 0;
        }
    }
}
