using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera PlayerCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public float speed = 10f;
    public double times = .2;
    public GameObject prefab;

    
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = PlayerCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, PlayerCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;
        }
        transform.position = pos;
         if(Input.GetKey("space"))
        {
            EggShoot();
        }

        
    }

    void EggShoot() {
        times -= 1 * Time.deltaTime;
        if(times <= 0){
            Instantiate(prefab, transform.position + (transform.forward*2), transform.rotation);
            times = .2f;
        }
    }
    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
