using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private CharacterController controller;
    public Transform cam;
    private Animator _animator;

    //重力
    public float Gravity;
    public Vector3 Velocity = Vector3.zero;
    public Transform GroundCheck;
    public float CheckRadious = 0.2f;
    private bool IsGround;
    public LayerMask layerMask;

    public float Speed;
    public float RotateSpeed = 2f;
    public float Speed_Normal;
    public float Speed_High;
    public float JumpHeight = 3f;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
        _animator = GameObject.Find("炭治郎").GetComponent<Animator>();
    }
    void Update()
    {
        mymove();
    }

    /**
    private void mtopmove()
    {
        IsGround = Physics.CheckSphere(GroundCheck.position, CheckRadious, layerMask);
        if (IsGround && Velocity.y < 0)
        {
            Velocity.y = 0;
        }
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");    
        var direction = new Vector3(h, 0, v).normalized;
        var move = direction * Speed * Time.deltaTime;
        controller.Move(move);

        var playscreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        var point = Input.mousePosition - playscreenPoint;
        var angle = Mathf.Atan2(point.x, point.y) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);

    }

    private void mmove()
    {
        IsGround = Physics.CheckSphere(GroundCheck.position, CheckRadious, layerMask);
        if (IsGround && Velocity.y < 0)
        {
            Velocity.y = 0;
        }
        if (Input.GetButtonDown("Jump") && IsGround)
        {
            Velocity.y += Mathf.Sqrt(JumpHeight * -2 * Gravity);
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        var move = transform.forward * Speed * v * Time.deltaTime;
        controller.Move(move);
        Velocity.y += Gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);
        
        transform.Rotate(Vector3.up,h*RotateSpeed);
    }
    **/
    
    private void mymove()
    {
        IsGround = Physics.CheckSphere(GroundCheck.position, CheckRadious, layerMask);
        if (IsGround && Velocity.y < 0)
        {
            Velocity.y = 0;
        }
        /**跳跃
        if (Input.GetKeyDown("space") && IsGround)
        {
            Velocity.y += Mathf.Sqrt(JumpHeight * -2 * Gravity);
        }
        **/
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(h, 0, v).normalized;
        
        if (direction!=Vector3.zero)
        {
            if (direction.magnitude>=0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                    turnSmoothTime);//平滑跟随摄像机
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                
                if (!Input.GetKey("left shift"))
                {
                    Speed = Speed_Normal;
                    _animator.SetBool("Acc",false);
                }
                if (Input.GetKey("left shift"))
                {
                    Speed = Speed_High;
                    _animator.SetBool("Acc",true);
                }
                controller.Move(moveDir.normalized * Speed * Time.deltaTime);
                _animator.SetBool("Move",true);
            }
        }
        else
        {
            _animator.SetBool("Move",false);
        }
        Velocity.y = Velocity.y + Gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);//重力
        
    }
}
