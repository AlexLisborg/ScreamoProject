using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreamScript : MonoBehaviour
{
    [SerializeField] private float width;
    [SerializeField] private float length;
    [SerializeField] private int numberOfSpots;
    [SerializeField] private GameObject spotPrefab;
    private List<GameObject> spots = new List<GameObject>();

    void Start()
    {
        for(int i = 0; i < numberOfSpots; i++)
        {
            GameObject spot = Instantiate(spotPrefab, transform);
            spot.transform.localScale = new Vector3(length, width, 1);
            spot.transform.localPosition = new Vector3((i + 0.5f) * length ,0, 0);
            spot.GetComponent<FovCollidable>().setOnBlocked(blockRest, freeRest);
            spots.Add(spot);
        }
    }

    private void blockRest(GameObject spot)
    {
        Debug.Log("block");
        bool found = false;
        foreach(GameObject s in spots) {
            if (found)
            {
                s.SetActive(false) ;
            }else if(s == spot)
            {
                Debug.Log("found");
                found = true;
            }
        }

    }

    public void freeRest(GameObject spot)
    {
        if (spot.active)
        {
            bool found = false;
            foreach (GameObject s in spots)
            {
                if (found)
                {
                    s.SetActive(true);
                }
                else if (s == spot)
                {
                    found = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
