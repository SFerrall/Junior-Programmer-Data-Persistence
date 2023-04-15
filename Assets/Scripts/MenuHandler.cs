using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    //public InputField nameField;
    public string playerName = "";
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        if(playerName.Length > 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Enter a username!");
        }
    }

    public void ReadStringInput()
    {
        playerName = inputField.text;
        //playerName = s.ToString();
        Debug.Log(playerName);
        //MainManager.GameInstance.playerName = playerName;
        GameInstance.gameInstance.playerName = playerName;
    }
}
