using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataDisplay : MonoBehaviour
{
    GameStatus gameStatus;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameStatusObject = GameObject.Find("GameStatus");
        if(gameStatusObject)
        {
            gameStatus = gameStatusObject.GetComponent<GameStatus>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStatus)
        {
            GetComponent<Text>().text = "experience: " + gameStatus.experience + ", rolls: " + gameStatus.rolls;
        }
    }
}
