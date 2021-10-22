using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Single<T> where T:class,new()
{
    protected static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }

    protected Single()
    {
        if (_instance != null)
        {
            Debug.LogError("this" + (typeof(T)).ToString() + " is not null");
        }
    }

    public virtual void Init()
    {
        Debug.Log( (typeof(T)).ToString() + "inited");
    }
    
}
