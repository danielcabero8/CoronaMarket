using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int health { get; private set; } = 0;
    public int time { get; private set; } = 0;
    public int rolls { get; private set; } = 0;
    /*Game state variables - END*/

    private float currentGameTime;

    public delegate void OnLevelStateChanged(LevelState oldState, LevelState newState);
    public static event OnLevelStateChanged LevelStateChanged;

    private static PlayStatus playStatusInstance;

    private void Start()
    {
        //If there is already a GameStatus object, delete the new instance
        if(playStatusInstance != null)
        {
            //but first check if we have changed states
            if(playStatusInstance.levelState != levelState)
            {
                if(LevelStateChanged != null)
                {
                    LevelStateChanged(playStatusInstance.levelState, levelState);
                }

                //Set the new state
                playStatusInstance.levelState = levelState;
            }


            Destroy(this.gameObject);
        }
        else
        {
            playStatusInstance = this; //set singleton instance to this
            DontDestroyOnLoad(this.gameObject); //do we really need this? no harm yet

            InitCallbacks();
            LoadPlayState();
        } 
    }
    private void Update()
    {
        if(levelState == LevelState.Play)
        {
            currentGameTime += Time.deltaTime;
            if(currentGameTime >= time)
            {
                EndPlay();
                currentGameTime = 0.0f;
            }
        }
    }

    private void EndPlay()
    {
        SceneManager.LoadScene("Frontend");
    }

    private void InitCallbacks()
    {
        Cart.ProductCollected += OnProductCollected;
    }
    
    private void OnProductCollected(Product product)
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

    private void SavePlayState()
    {
        PlayerPrefs.SetInt("play_health", health);
        PlayerPrefs.SetInt("play_time", time);
        PlayerPrefs.SetInt("play_rolls", rolls);
    }

    private void LoadPlayState()
    {
        health = PlayerPrefs.GetInt("play_health", 0);
        time = PlayerPrefs.GetInt("play_time", 30);
        rolls = PlayerPrefs.GetInt("play_rolls", 0);
    }

    public void ResetPlayState()
    {
        PlayerPrefs.DeleteKey("play_health");
        PlayerPrefs.DeleteKey("play_time");
        PlayerPrefs.DeleteKey("play_rolls");
        LoadPlayState(); //Instantly load the defaults
    }
}
