using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Concurrent;
using System;

public class ThreadingCheat : MonoBehaviour
{
    private static ConcurrentBag<Action> Actions = new ConcurrentBag<Action>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static void RegisterActionForMainThread(Action action)
    {
        Actions.Add(action);
    }
    // Update is called once per frame
    void Update()
    {
        if(Actions.TryTake(out Action action)) action();
    }
}
