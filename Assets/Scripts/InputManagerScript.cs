using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    Dictionary<KeyCode,Dictionary<KeyEvent, List<InputEvent>>> precedenceForKey = new Dictionary<KeyCode, Dictionary<KeyEvent, List<InputEvent>>>();

    public Action addAction(int precedence, KeyCode key, KeyEvent keyEvent , Action whenKeyPressed )
    {
        if (!precedenceForKey.Keys.Contains(key)){
            precedenceForKey[key] = new Dictionary<KeyEvent, List<InputEvent>>();
        }
        if (!precedenceForKey[key].Keys.Contains(keyEvent))
        {
            precedenceForKey[key][keyEvent] = new List<InputEvent>();
        }
        bool hasInserted = false;
        InputEvent newEvent = new InputEvent(precedence, key, whenKeyPressed);    
        List<InputEvent> inputEvents = precedenceForKey[key][keyEvent];
        for(int i = 0; i < inputEvents.Count; i++)
        {
            InputEvent e= inputEvents[i];

            if(e.precedence > precedence)
            {
                inputEvents.Insert(i, newEvent);
                hasInserted = true;
            }
        }
        if(!hasInserted)
        {
            inputEvents.Add(newEvent);
        }

        return () => removeAction(precedence, key, keyEvent, whenKeyPressed);
    }

    public bool removeAction(int precedence, KeyCode key, KeyEvent keyEvent, Action whenKeyPressed)
    {
        List<InputEvent> precedencies = precedenceForKey[key][keyEvent];

        foreach(InputEvent ie in precedencies)
        {
            if (ie.precedence == precedence && ie.action == whenKeyPressed )
            {
                precedencies.Remove(ie);
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        
        foreach(KeyCode key in precedenceForKey.Keys)
        {
            if (Input.GetKey(key))
            {
                if (precedenceForKey[key].Keys.Contains(KeyEvent.Key))
                    executeAction(key, KeyEvent.Key);
            }
            if (Input.GetKeyDown(key))
            {
                if (precedenceForKey[key].Keys.Contains(KeyEvent.KeyDown))
                    executeAction(key, KeyEvent.KeyDown);
            }
            if (Input.GetKeyUp(key))
            {
                if (precedenceForKey[key].Keys.Contains(KeyEvent.KeyUp))
                    executeAction(key, KeyEvent.KeyUp);
            }

        }
    }

    private void executeAction(KeyCode keyCode, KeyEvent keyEvent)
    {
        precedenceForKey[keyCode][keyEvent][0].action();
    }



    public enum KeyEvent
    {
        Key,
        KeyDown,
        KeyUp
    }

    private class InputEvent
    {
        public InputEvent(int precedence, KeyCode keyCode,  Action action)
        {
            this.precedence = precedence;
            this.keyCode = keyCode;  
            this.action = action;
        }
        public int precedence { get; private set; }
        public KeyCode keyCode { get; private set; }

        public Action action { get; private set; }
    }

}



