using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseEvent<T> where T : AbstractEventData
{
    public static event Action<T> OnEventTrigger;
    public abstract T Data { get; }

    public void Trigger()
    {
        OnEventTrigger?.Invoke(Data);
    }

    public static void ClearListener()
    {
        OnEventTrigger = null;
    }
}
