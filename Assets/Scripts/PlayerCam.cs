using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // public Transform player;
    // public PolygonCollider2D mapBounds;
    // public Camera mainCam;
    // private float xMin, xMax, yMin, yMax;
    // private float camY,camX;
    // private float camOrthsize;
    // private float cameraRatio;
    
    // // Start is called before the first frame update
    // void Start()
    // {
    //     xMin = mapBounds.bounds.min.x;
    //     xMax = mapBounds.bounds.max.x;
    //     yMin = mapBounds.bounds.min.y;
    //     yMax = mapBounds.bounds.max.y;
    //     mainCam = GetComponent<Camera>();
    //     camOrthsize = mainCam.orthographicSize;
    //     cameraRatio = (xMax + camOrthsize) / 2.0f;
    // }

    // // Update is called once per frame
    // void Update() {        
    //     camY = Mathf.Clamp(player.position.y, yMin + (camOrthsize), yMax - (camOrthsize));
    //     camX = Mathf.Clamp(player.position.x, xMin + (cameraRatio), xMax - (cameraRatio));
    //     this.transform.position = new Vector3(camX, camY, this.transform.position.z);
    // }
}
