using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu: MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void youWon()
    {
        SceneManager.LoadScene("MainMenu");
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScreen");
    }
    public void Options(){
        SceneManager.LoadScene("OptionScreen");
    }
    public void Help() {
        SceneManager.LoadScene("MainMenu");
    }
}
