using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cart.ProductCollected += OnProductCollected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnProductCollected(Product product)
    {
        Object.Destroy(product.gameObject);
    }
}
