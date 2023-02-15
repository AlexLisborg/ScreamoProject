using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconBoxScript : MonoBehaviour
{
    private Action<int> whenClikced;
    private int id;
    public void set(Action<int> whenClikced, int id)
    {
        gameObject.SetActive(true);
        this.whenClikced = whenClikced;
        this.id = id;
    }
    void OnMouseDown()
    {
        whenClikced.Invoke(id);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
