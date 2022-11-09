using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tato : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Tato Destroyed");
            Destroy(gameObject);
        }
    }
}
