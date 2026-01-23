using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputSystem InputSystem;
    private Vector2 Direction;
    private Rigidbody rb;
    [Header("玩家移动")]
    public float Speed;
    public float JumpF;
    [Header("检测点")]
    public Check check;
    [Header("状态")]
    public bool isGround;//是否在地面上
    private void Awake()
    {
        InputSystem = new InputSystem();
        rb = GetComponent<Rigidbody>();
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
        Direction = InputSystem.Player.Move.ReadValue<Vector2>();
        rb.velocity=new Vector2 (Direction.x*Speed,rb.velocity.y);
    }
    private void Jump(InputAction.CallbackContext context)
    {
        isGround = check.isCheck;
        if(isGround)
        rb.AddForce(new Vector3(0f, JumpF, 0f), ForceMode.Impulse);
    }

}
