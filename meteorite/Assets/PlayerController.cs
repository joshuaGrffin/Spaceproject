﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput pInput;
    [SerializeField]
    public Ship shipDef;
    
    [SerializeField]
    float thrust;
    float health;
    float maxHealth;
    float baseShieldPower;
    float currentShieldPower;
    float shieldRechargeRate;

    //to be removed once game manager is created
    [SerializeField]
    int playerNumber;

    [SerializeField]
    GameObject visuals;
    [SerializeField]
    float YawAngle;


    Vector2 thrustDirection;
    Vector2 rot;
    
    float angle = 0;
    
    Rigidbody rb;
    private void Start()
    {
        init();
    }

    private void Update()
    {
        thrustDirection = pInput.GetInput_LeftStick();
        rotate();
        actions();  
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(thrustDirection * thrust);
    }

    void actions()
    {
        //switch weapons
        if (pInput.getSwitchWeapons())
        {
            Debug.Log("switched weapons");
        }

    }

    void rotate() {
        rot = pInput.GetInput_RightStick();
        if (rot.magnitude > 0)
        {
            angle = Mathf.Atan2(rot.x, rot.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, -angle), 1);
        }
        visuals.transform.localEulerAngles = Vector3.Lerp(visuals.transform.eulerAngles, new Vector3(0, -thrustDirection.x * YawAngle, visuals.transform.localEulerAngles.z), 1);
    }

    public void init()
    {
        pInput = new PlayerInput(playerNumber);
        rb = GetComponent<Rigidbody>();

        //set all stats here
        maxHealth = shipDef.health;
        health = maxHealth;
        thrust = shipDef.thrustForce;
        baseShieldPower = shipDef.shieldPower;
        shieldRechargeRate = shipDef.rechargeRate;
        currentShieldPower = baseShieldPower;
        rb.mass = shipDef.mass;

    }

    public void doDamage(float damage)
    {
        health -= damage;
    }
}
