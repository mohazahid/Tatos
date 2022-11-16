using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleDifficulty : MonoBehaviour
{
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
}
