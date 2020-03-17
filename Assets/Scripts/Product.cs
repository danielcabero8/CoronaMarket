using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Product : MonoBehaviour
{
    enum ProductType
    {
        ToiletRoll,
        Can,
        Pasta,
        Invalid
    }

    [SerializeField]
    ProductType productType;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var touch in Input.touches)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(HasProductBeenClicked())
        {
            OnButtonClicked();
        }    
    }

    bool HasProductBeenClicked()
    {
        Collider2D collider = GetComponent<Collider2D>();
        return Array.Exists(Input.touches, (touch) =>
        {
            return collider.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position));
        });
    }

    public void OnButtonClicked()
    {
        //When item gets clicked, we activate it´s physics
        Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();
        if(rigidBody2D)
        {
            rigidBody2D.gravityScale = 1;
        }
    }
}
