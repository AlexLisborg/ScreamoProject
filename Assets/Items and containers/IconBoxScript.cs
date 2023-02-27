using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconBoxScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    private Action<GameObject> whenClikced;
    public void set(Action<GameObject> whenClikced)
    {
        gameObject.SetActive(true);
        this.whenClikced = whenClikced;
    }
    void OnMouseDown()
    {
        Debug.Log("clicked"); ;
        whenClikced(gameObject);
    }

 

    public void changeIcon(Sprite icon)
    {
        spriteRenderer.sprite = icon;
    }
}
