using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POVCAM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color color = GetComponent<Renderer>().material.color;
        color.a -= 0.1f;
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            GetComponent<Renderer>().material.SetAlpha(GetComponent<Renderer>().material.color.a - .25F);
        }
    }
}
    public static class ExtensionMethods
    {
    public static void SetAlpha(this Material material, float value)
    {
        Color color = material.color;
        color.a = value;
        material.color = color;
    }
}

