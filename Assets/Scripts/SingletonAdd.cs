using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonAdd : MonoBehaviour
{
    void Awake()
    {
        //Add this GameObject to List when it is created
        Singleton.instance.allObjects.Add(gameObject);
    }

    void OnDestroy()
    {
        //Remove this GameObject from the List when it is about to be destroyed
        Singleton.instance.allObjects.Remove(gameObject);
    }
}
