using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.IO;

public class CreditsScript : MonoBehaviour
{
    public TMP_Text credits;
    public FileInfo theSourceFile;
    protected StreamReader reader = null;
    protected string text = "";

    void Start()
    {
        reader = theSourceFile.OpenText();
    }

    void Update()
    {
        if (text != null)
        {
            text = reader.ReadLine();
            credits.text = text;
        }
    }
}
