using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    public delegate void OnProductCollected(GameObject gameObject);
    public static event OnProductCollected ProductCollected;

    private Collider2D cartCollider;
    // Start is called before the first frame update
    void Start()
    {
        cartCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Product product = other.GetComponent<Product>();
        if(product)
        {
            ProductCollected(other.gameObject);
        }
    }
}
