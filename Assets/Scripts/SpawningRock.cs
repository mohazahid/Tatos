using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningRock : MonoBehaviour
{
    // Start is called before the first frame update
    private Player player;
    void Start()
    {
        player = (GameObject.Find("Player_0")).GetComponent<Player>()   ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            if(player.rockCount >=5) {
            } else {
            Destroy(gameObject);
            }
        }
    }
}
