using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//T is a generic
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour //makes sure all classes passed in are of type monobehavior
{
    //static can be refrenced just by using the class name. what makes the singleton globaly availble
    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    //protected means can be accessed by inheriting classed, virtual means it can be overridden by inheriting class
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
