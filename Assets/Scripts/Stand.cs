using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    [SerializeField]
    private StandDataAsset standDataAsset;

    public Vector3[] shelfSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        int randomMax = standDataAsset.shelves.Length;
        foreach (var spawnPosition in shelfSpawnPoints)
        {
            int ShelfIndex = Random.Range(0, randomMax);
            GameObject newShelf = Instantiate<GameObject>(standDataAsset.shelves[ShelfIndex]);
            newShelf.transform.position = spawnPosition;

            Shelf shelf = newShelf.GetComponent<Shelf>();
            if(shelf)
            {
                SShelfData shelfData;
                shelfData.infectedChance = standDataAsset.infectionChance;
                shelfData.rareChance = standDataAsset.rareChance;
                shelf.InitializeShelf(shelfData);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
