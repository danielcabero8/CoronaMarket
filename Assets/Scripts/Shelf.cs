using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SShelfData
{
    int RareChance;
}

public class Shelf : MonoBehaviour
{
    private SShelfData shelfData;

    public void InitializeShelf(SShelfData shelfDataIn)
    {
        shelfData = shelfDataIn;

        ProductSpawn[] ShelfProducts = GetComponentsInChildren<ProductSpawn>();
        foreach (var productSpawn in ShelfProducts)
        {
            CreateProductObject(productSpawn);
        }
    }

    private void CreateProductObject(ProductSpawn productSpawn)
    {
        GameObject newProduct = CreateProductObjectForSpawn(productSpawn);
        
        //Set spawn position for this product
        Transform spawnTransform = productSpawn.transform;
        newProduct.transform.position = spawnTransform.position;
        newProduct.transform.rotation = spawnTransform.rotation;

        //Initailize product component
        Product product = newProduct.GetComponent<Product>();
        if(product)
        {
            product.productType = productSpawn.productType;
        }
    }
 
    private GameObject CreateProductObjectForSpawn(ProductSpawn product)
    {
        //TODO: Run rarity algorithm
        //TODO: Hook data asset with prefabs
        //TODO: Instantiate object for the prefab
        GameObject newGameObject = new GameObject();
        return newGameObject;
    }
}
