using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePointerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private GameObject[] collectibles;
    public GameObject closestCollectible;
    float hideDistance = 200;
    public GameObject Arrow;

    void Start()
    {
        collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        if (collectibles.Length > 0)
        {
            closestCollectible = collectibles[0];
            SetArrowActive(true);
            FindClosest();
        }
        else
        {
            SetArrowActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetArrowActive(false);
        collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        if (collectibles.Length > 0)
        {
            FindClosest();
            if (closestCollectible != null)
            {
                var dir = closestCollectible.transform.position - Player.transform.position;
                if (dir.magnitude < hideDistance)
                {
                    SetArrowActive(false);
                }
                else
                {
                    SetArrowActive(true);
                }
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Debug.Log("Closest Collectible: " + closestCollectible.name);
            }
        }

    }

    void FindClosest()
    {
        if (collectibles.Length > 0)
        {
            if (closestCollectible != null)
            {

                var dist = Vector3.Distance(Player.transform.position, closestCollectible.transform.position);
                for (int i = 0; i < collectibles.Length; i++)
                {
                    var tempDist = Vector3.Distance(Player.transform.position, collectibles[i].transform.position);
                    if (tempDist < dist)
                    {
                        closestCollectible = collectibles[i];
                    }
                }
            }
            else
            {
                if (collectibles.Length > 0)
                {
                    closestCollectible = collectibles[0];
                }

            }
        }
    }
    void SetArrowActive(bool value)
    {
        Arrow.SetActive(value);
    }
}
