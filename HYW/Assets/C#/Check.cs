using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class Check : MonoBehaviour
{
    [Header("¼ì²âµã²ÎÊý")]
    public bool isCheck=false;
    public float CheckRadius;//¼ì²âÇòµÄ°ë¾¶
    public LayerMask LayerMask;
    private void Update()
    {
        Checking();
    }
    public void Checking()
    {
      isCheck =  Physics.CheckSphere(transform.position, CheckRadius, LayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, CheckRadius);
    }
}
