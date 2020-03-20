using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public static MySceneManager mySceneManagerInstance {get; private set;}
    private static MySceneManager CreateSceneManager()
    {
        MySceneManager newSeneManager = new MySceneManager();
        return newSeneManager;
    }

    private void Start()
    {
        //If there is already a GameStatus object, delete the new instance
        if(mySceneManagerInstance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            mySceneManagerInstance = this; //set singleton instance to this
            DontDestroyOnLoad(this.gameObject); //do we really need this? no harm yet
        } 
    }

    public static void OnButtonClicked(GenericButtonType buttonType)
    {
        if(!mySceneManagerInstance)
        {
            Debug.Log("MySceneManager::OnButtonClicked - No valid scene manager instance. cannot proceed"); 
            return;
        }

        switch(buttonType)
        {
            case GenericButtonType.Play:
            {
                mySceneManagerInstance.LoadScene("PlayLevel");
                break;
            }
            case GenericButtonType.NewGame:
            default:
                break;
        }

    }
}
