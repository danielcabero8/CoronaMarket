using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StandData", menuName = "DataAssets/Stand", order = 1)]
public class StandDataAsset : ScriptableObject
{
    [Range(0,100)]
    public int InfectionChance = 0;

    [Range(0,100)]
    public int RareChance = 0;
    
    public GameObject[] shelves;
}
