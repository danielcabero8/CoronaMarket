using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

[System.Serializable]
public class CollectionDictionary : SerializableDictionaryBase<ProductID, GameObject> {} 
 
[CreateAssetMenu(fileName = "ProductCollection", menuName = "DataAssets/ProductCollection", order = 2)]
public class ProductCollection : ScriptableObject
{
    public string indetifier;
    public CollectionDictionary collection;
}