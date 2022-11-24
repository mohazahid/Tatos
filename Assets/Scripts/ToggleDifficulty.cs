using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToggleDifficulty : MonoBehaviour
{
    public Toggle buttonEasy;
    public Toggle buttonNormal;
    public Toggle buttonHard;
    public static string difficulty = "Easy";
    // Start is called before the first frame update
    public void Easy(){
        difficulty = "Easy";
    }
    public void Normal(){
        difficulty = "Normal";
    }
    public void Hard(){
        difficulty = "Hard";
    }
    
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void Start()
    {
        Debug.Log("Difficulty: " + difficulty);
        if(difficulty == "Easy"){
             buttonEasy.isOn = true;
            buttonHard.isOn = false; 
            buttonNormal.isOn = false;
        }
        else if(difficulty == "Normal"){
           buttonNormal.isOn = true;
            buttonEasy.isOn = false;
            buttonHard.isOn = false;  
        }
        else if(difficulty == "Hard"){
            buttonHard.isOn = true;
            buttonEasy.isOn = false;
            buttonNormal.isOn = false;
        }
       
    }

    
}
