using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputSystem InputSystem;
    public Vector2 Direction;
    private Rigidbody rb;
    public Animator anim;
    public GameObject rig;
    [Header("玩家移动")]
    public float Speed;
    public float JumpF;
    [Header("检测点")]
    public Check check;
    [Header("状态")]
    public bool isGround;//是否在地面上
    public bool isDie;
    public bool isRun;
    private void Awake()
    {
        InputSystem = new InputSystem();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        InputSystem.Enable();
        InputSystem.Player.Jump.started += Jump;
    }



    private void OnDisable()
    {
        InputSystem.Disable();
        InputSystem.Player.Jump.started -= Jump;
    }
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        anim.SetBool("isRun", isRun);
        Direction = InputSystem.Player.Move.ReadValue<Vector2>();
        rb.velocity=new Vector2 (Direction.x*Speed,rb.velocity.y);
        if (Direction.x != 0)
        {
            isRun = true;
            if(Direction.x>0)
            rig.transform.localScale = new Vector3( rig.transform.localScale.x,100,rig.transform.localScale.z);
            if (Direction.x < 0)
                rig.transform.localScale = new Vector3(rig.transform.localScale.x, -100, rig.transform.localScale.z);
        }
        else
        {
            isRun = false;
            rig.transform.localScale = new Vector3(rig.transform.localScale.x, rig.transform.localScale.y, rig.transform.localScale.z);
        }
    }
    private void Jump(InputAction.CallbackContext context)
    {
        isGround = check.isCheck;
        if(isGround)
        rb.AddForce(new Vector3(0f, JumpF, 0f), ForceMode.Impulse);
    }

}
