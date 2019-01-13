using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable ]
public class MyEvent : UnityEvent<int> { }

[System.Serializable]
public class myNotificationObject<T> {

    private int data;

    public myNotificationObject(int t)
    {
        Value = t;
    }

    public myNotificationObject()
    {
        Event = new MyEvent();
    }

    ~myNotificationObject()
    {
        Dispose();
    }

    public MyEvent Event;

    public int Value
    {
        get
        {
            return data;
        }
        set
        {
            data = value;
            Notice();
        }
    }

    private void Notice()
    {
        if (Event != null) Event.Invoke(data);
    }

    public void Dispose()
    {
        Event.RemoveAllListeners();
    }
}
