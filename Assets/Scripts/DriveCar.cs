using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriveCar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private Rigidbody2D _carRb;
    [SerializeField] private float _speed = 150f;
    [SerializeField] private float _rotationSpeed = 300f;

    private float _moveInput;
    private int direction;

    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        MoveLogic();
        MoveMobile();
    }

    void GetInput()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
    }

    void MoveLogic()
    {
        _frontTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _carRb.AddTorque(_moveInput * _rotationSpeed * Time.fixedDeltaTime);
    }

    void MoveMobile()
    {
        _frontTireRB.AddTorque(direction * _speed * Time.deltaTime);
        _backTireRB.AddTorque(direction * _speed * Time.deltaTime);
        _carRb.AddTorque(direction * _rotationSpeed * Time.deltaTime);
    }

    public void CarInputMobile(int dir)
    {
        SoundScript.PlaySound("Vehicle_Car_Engine");
        direction = dir;
    }

}