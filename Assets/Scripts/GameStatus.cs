using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    /*Game state variables - START*/
    private int experience = 0;
    private int lives = 0;
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

        LoadGameState();
    }

    void SaveGameState()
    {
        PlayerPrefs.GetInt("experience", experience);
        PlayerPrefs.GetInt("lives", lives);
    }

    void LoadGameState()
    {
        PlayerPrefs.GetInt("experience", 0);
        PlayerPrefs.GetInt("lives", 3);
    }

    void ResetGameState()
    {
        PlayerPrefs.DeleteAll();
        LoadGameState(); //Instantly load the defaults
    }
}
