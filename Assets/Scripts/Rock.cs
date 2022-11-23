using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 40;
        transform.Translate( Vector3.up* speed * Time.deltaTime);
        
    }
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}