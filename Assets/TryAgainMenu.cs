using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void youWon()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
