using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class Global : MonoBehaviour
{
    GameObject[] remaining;
    public TMP_Text statText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //remaining = GameObject.FindGameObjectsWithTag("Collectible");
        statText.SetText("Collected: " + (8) + "/8");
    }
}
