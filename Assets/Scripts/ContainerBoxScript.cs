using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContainerBoxScript : MonoBehaviour
{

    public GameObject iconBox;
    private int with;
    private List<Sprite> itemIcons;
    private Container container;

    // Start is called before the first frame update

    public void set(int with, List<Sprite> itemIcons, Action<int> onItemClicked)
    {
        this.with = with;
        this.itemIcons = itemIcons; 
        int hight = itemIcons.Count % with;
        gameObject.transform.localScale = new Vector3(with, hight, 1);
       
        for (int i = 1;i < hight; i++) {
            for(int j = 1; j < with;j++)
            {
                int index = i * hight + j;
                GameObject itemIcon = Instantiate(iconBox, gameObject.transform);
                itemIcon.GetComponent<SpriteRenderer>().sprite = itemIcons.ElementAt(index);
                itemIcon.GetComponent<IconBoxScript>().set(onItemClicked, index);
                itemIcon.transform.position = new Vector3(j, i, 1);
            }
        }
       
    }


    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
