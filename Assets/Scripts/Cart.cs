using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public delegate void OnProductCollected(Product gameObject);
    public static event OnProductCollected ProductCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        Product product = other.GetComponent<Product>();
        if(product)
        {
            ProductCollected(product);
        }
    }
}
