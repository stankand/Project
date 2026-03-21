using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderContol: MonoBehaviour
{

    public float radius = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector("_Position", transform.position);
        Shader.SetGlobalFloat("_Radius", radius);
    }
}
