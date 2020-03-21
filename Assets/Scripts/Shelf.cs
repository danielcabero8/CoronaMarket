using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SShelfData
{
    public int infectedChance;
    public int rareChance;
}

public class Shelf : MonoBehaviour
{
    public ProductCollection productCollection;
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
    }
 
    private GameObject CreateProductObjectForSpawn(ProductSpawn product)
    {
        //TODO: Run rarity algorithm
        ProductID productID = GenerateIDFromProductType(product.productType);
        GameObject newProductTemplate = productCollection.collection[productID];
        GameObject newProduct = Instantiate<GameObject>(newProductTemplate);
        return newProduct;
    }

    private ProductID GenerateIDFromProductType(ProductType productType)
    {
        int infectedMax = shelfData.infectedChance;
        int rareMax = infectedMax + shelfData.rareChance;
        int randomTypeNumber = Random.Range(1, 100);

        if(randomTypeNumber  < infectedMax)
        {
            //item is infected
            return GetInfected(productType);
        }
        else if(randomTypeNumber <  rareMax)
        {
            //item is rare
            return GetRare(productType);
        }
        else
        {
            //item is normal
            return GetDefault(productType);
        }
    }

    private ProductID GetInfected(ProductType productType)
    {
        switch(productType)
        {
            case ProductType.ToiletRoll:
                return ProductID.standard_infected_ToiletRoll;
            case ProductType.Can:
                return ProductID.standard_infected_Can;
            case ProductType.Pasta:
                return ProductID.standard_infected_Pasta;
            case ProductType.Large_ToiletRoll:
                return ProductID.large_infected_ToiletRoll;
            case ProductType.Large_Can:
                return ProductID.large_infected_Can;
            case ProductType.Large_Pasta:
                return ProductID.large_infected_Pasta;    
            default:
                return ProductID.invalid;
        }
    }

    private ProductID GetRare(ProductType productType)
    {
        switch(productType)
        {
            case ProductType.ToiletRoll:
                return ProductID.standard_rare_ToiletRoll;
            case ProductType.Can:
                return ProductID.standard_rare_Can;
            case ProductType.Pasta:
                return ProductID.standard_rare_Pasta;
            case ProductType.Large_ToiletRoll:
                return ProductID.large_rare_ToiletRoll;
            case ProductType.Large_Can:
                return ProductID.large_rare_Can;
            case ProductType.Large_Pasta:
                return ProductID.large_rare_Pasta;    
            default:
                return ProductID.invalid;
        }
    }

    private ProductID GetDefault(ProductType productType)
    {
        switch(productType)
        {
            case ProductType.ToiletRoll:
                return ProductID.standard_ToiletRoll;
            case ProductType.Can:
                return ProductID.standard_Can;
            case ProductType.Pasta:
                return ProductID.standard_Pasta;
            case ProductType.Large_ToiletRoll:
                return ProductID.large_ToiletRoll;
            case ProductType.Large_Can:
                return ProductID.large_Can;
            case ProductType.Large_Pasta:
                return ProductID.large_Pasta;    
            default:
                return ProductID.invalid;
        }
    }
}
