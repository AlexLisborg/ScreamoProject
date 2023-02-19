using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContainerBoxScript : MonoBehaviour
{

    public GameObject iconBox;
    private List<GameObject> icons= new List<GameObject>();
    private Action<int> onClickedItem;
    private int with;
    private int hight;
    private Func<Vector3> pos;

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (gameObject.active)
        {
            Vector3 followVec = pos();
            followVec.z = transform.position.z;
            transform.position = followVec;
        }
         
    }

    public void set(int with, int hight)
    {
       
        this.with = with;
        this.hight = hight;
        gameObject.transform.localScale = new Vector3(with, hight, 1);
    }

    public void show(Func<Vector3> pos)
    {
        gameObject.SetActive(true);
        this.pos = pos;
    }
    public void hide()
    {
        gameObject.SetActive(false);
    }

    public void setOnwhenClicked(Action<int> onClickedItem)
    {
        this.onClickedItem = onClickedItem;
    }

    private void iconCallThisWhenClicked(GameObject icon)
    {
        onClickedItem(icons.IndexOf(icon));
    }

    private Vector3 getPosOfIndex(int index)
    {
        Vector3 upperRughtCorner = new Vector3(-with / 2f + 0.5f, hight / 2f - 0.5f, 1) + transform.position;
        return new Vector3(index % with, -index / with, 1) + upperRughtCorner;
    }

    public void addNewIcon(Sprite icon)
    {

        float withPart = 1.0f / (float)with;
        float heightPart = 1.0f / (float)hight;
     
        GameObject itemIcon = Instantiate(iconBox, gameObject.transform);

        itemIcon.GetComponent<IconBoxScript>().changeIcon(icon) ;
        itemIcon.GetComponent<IconBoxScript>().set(iconCallThisWhenClicked);
        itemIcon.transform.localScale = new Vector3(withPart, heightPart, 1);

        itemIcon.transform.position = getPosOfIndex(icons.Count);

        icons.Add(itemIcon);
    }

    public void removeIcon(int index)
    {

        Destroy(icons.ElementAt(index));
        icons.RemoveAt(index);

        for(int i = index; i < icons.Count; i++)
        {
            icons[i].transform.position = getPosOfIndex(i);
        }
 
        
    }


    
}
