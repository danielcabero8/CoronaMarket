using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    /*Game state variables - START*/
    public int experience {get; private set;} = 0;
    public int lives {get; private set;} = 0;
    public int rolls {get; private set;} = 0;
    /*Game state variables - END*/

    private static GameStatus gameStatusInstance;

    void Start()
    {
        //If there is already a GameStatus object, delete the new instance
        if(gameStatusInstance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        gameStatusInstance = this; //set singleton instance to this
        DontDestroyOnLoad(this.gameObject); //do we really need this? no harm yet

        InitCallbacks();
        LoadGameState();
    }

    void InitCallbacks()
    {
        PlayStatus.LevelStateChanged += OnLevelStateChanged;
    }

    public void LoadLevel(string newLevel)
    {
        SceneManager.LoadScene(newLevel);
    }

    void OnLevelStateChanged(LevelState oldState, LevelState newState)
    {
        //going back from game to menu
        if(oldState == LevelState.Play && newState == LevelState.Menu)
        {
            GameObject playStatusObject = GameObject.Find("PlayStatus");
            if(playStatusObject)
            {
                PlayStatus playStatus = playStatusObject.GetComponent<PlayStatus>();
                RunPlayEvaulation(playStatus);
                SaveGameState();
                playStatus.ResetPlayState();
            }
        }
    }

    void RunPlayEvaulation(PlayStatus playStatus)
    {
        experience += playStatus.health * 3;
        rolls += playStatus.rolls;
    }

    void SaveGameState()
    {
        PlayerPrefs.SetInt("experience", experience);
        PlayerPrefs.SetInt("lives", lives);
        PlayerPrefs.SetInt("rolls", rolls);
        //PlayerPrefs.Save();

        int testing = PlayerPrefs.GetInt("experience", -1);
        Debug.Log(testing);
    }

    void LoadGameState()
    {
        experience = PlayerPrefs.GetInt("experience", 0);
        lives = PlayerPrefs.GetInt("lives", 3);
        rolls = PlayerPrefs.GetInt("rolls", 0);
    }

    void ResetGameState()
    {
        PlayerPrefs.DeleteAll();
        LoadGameState(); //Instantly load the defaults
    }
}
