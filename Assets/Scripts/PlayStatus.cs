using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelState
{
    Menu,
    Play
}

public class PlayStatus : MonoBehaviour
{
    [SerializeField]
    private LevelState levelState;

    /*Game state variables - START*/
    private int health = 0;
    private int time = 0;
    private int rolls = 0;
    /*Game state variables - END*/

   private static PlayStatus playStatusInstance;

    void Start()
    {
        //If there is already a GameStatus object, delete the new instance
        if(playStatusInstance != null)
        {
            //but first override level state so that we know when we are going from frontend to game and viceversa
            playStatusInstance.levelState = levelState;

            Destroy(this.gameObject);
            return;
        }

        playStatusInstance = this; //set singleton instance to this
        DontDestroyOnLoad(this.gameObject); //do we really need this? no harm yet

        InitCallbacks();
        LoadPlayState();
    }

    void InitCallbacks()
    {
        Cart.ProductCollected += OnProductCollected;
    }
    
    void OnProductCollected(Product product)
    {
        switch (product.productType)
        {
            case ProductType.ToiletRoll:
            {
                rolls += 4;
                break;
            }
            case ProductType.Pasta:
            {
                health += 3;
                break;
            }
            case ProductType.Can:
            {
                health += 4;
                break;
            }
            default:
                break;
        }
    }

    void SavePlayState()
    {
        PlayerPrefs.GetInt("health", health);
        PlayerPrefs.GetInt("time", time);
        PlayerPrefs.GetInt("rolls", rolls);
    }

    void LoadPlayState()
    {
        health = PlayerPrefs.GetInt("health", 0);
        time = PlayerPrefs.GetInt("time", 30);
        time = PlayerPrefs.GetInt("rolls", 0);
    }

    void ResetPlayState()
    {
        PlayerPrefs.DeleteAll();
        LoadPlayState(); //Instantly load the defaults
    }
}
