using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockShoot : MonoBehaviour
{
    Vector3 mouse_pos;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    private AudioSource RockSound;
    // Start is called before the first frame update
    void Start()
    {
        force = 25;
        rb = this.GetComponent<Rigidbody2D>();
        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mouse_pos - transform.position;
        Vector3 rotation = transform.position - mouse_pos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;    
        transform.rotation = Quaternion.Euler(0f, 0f, rot);     
        timer = 5;
        RockSound = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Rock")
        {
        }
        else
        {
            RockSound.enabled = true;
            RockSound.Play();
            Destroy(gameObject);
            

        }
    }
}
