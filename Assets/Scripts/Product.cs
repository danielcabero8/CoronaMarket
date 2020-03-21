using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProductID
{
    standard_ToiletRoll,
    standard_Can,
    standard_Pasta,

    standard_infected_ToiletRoll,
    standard_infected_Can,
    standard_infected_Pasta,

    standard_rare_ToiletRoll,
    standard_rare_Can,
    standard_rare_Pasta,

    large_ToiletRoll,
    large_Can,
    large_Pasta,

    large_infected_ToiletRoll,
    large_infected_Can,
    large_infected_Pasta,

    large_rare_ToiletRoll,
    large_rare_Can,
    large_rare_Pasta,

    invalid
}

public enum ProductType
{
    ToiletRoll,
    Can,
    Pasta,
    Large_ToiletRoll,
    Large_Can,
    Large_Pasta,

    Invalid
}

public class Product : MonoBehaviour
{
    //TODO: Make it non serializeable as products won´t be instanced in level, only through ProductSpawns
    public ProductType productType;
    public ProductID productID;

    // Update is called once per frame
    void Update()
    {
        if(HasProductBeenTouched() || HasProductBeenClicked())
        {
            OnButtonClicked();
        }    
    }

    bool HasProductBeenTouched()
    {
        Collider2D collider = GetComponent<Collider2D>();
        return Array.Exists(Input.touches, (touch) =>
        {
            return collider.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position));
        });
    }

    bool HasProductBeenClicked()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Collider2D collider = GetComponent<Collider2D>();
            return collider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
       return false;
    }

    public void OnButtonClicked()
    {
        //When item gets clicked, we activate it´s physics
        ActivateGravity();  
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        //When item collides with any other object
        ActivateGravity();      
    }

    void ActivateGravity()
    {
        Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();
        if(rigidBody2D)
        {
            rigidBody2D.gravityScale = 1;
        }
    }
}
