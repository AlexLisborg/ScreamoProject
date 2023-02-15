using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletContainer : Container
{
    public GameObject bandageRef;

    private void Start()
    {
        List<GameObject> list = new List<GameObject>();
        GameObject a = Instantiate(bandageRef);
     
        list.Add(Instantiate(bandageRef));
        list.Add(Instantiate(bandageRef));


        foreach (GameObject obj in list)
        {
            addItem(obj.GetComponent<ItemScript>());
        }
    }
}
