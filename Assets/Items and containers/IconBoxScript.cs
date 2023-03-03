using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconBoxScript : MonoBehaviour
{
    [SerializeField] private GameObject Icon;
    private Action<GameObject> whenClikced;
    public void set(Action<GameObject> whenClikced)
    {
        gameObject.SetActive(true);
        this.whenClikced = whenClikced;

    }
    void OnMouseDown()
    {
        whenClikced(gameObject);
    }

 

    public void changeIcon(Sprite icon)
    {
        Icon.GetComponent<SpriteRenderer>().sprite = icon;
    }
}
