using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GenericButtonType
{
    Play,
    NewGame
}

public class GenericButton : MonoBehaviour
{
    [SerializeField]
    private GenericButtonType buttonType;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        if(button)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    void OnClick()
    {
        MySceneManager.OnButtonClicked(buttonType);
    }
}
