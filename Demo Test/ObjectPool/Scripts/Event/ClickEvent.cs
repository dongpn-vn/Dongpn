using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    ClickEventType,
    MoveEventType,
    KillEventType
}

public class ClickEvent : BaseEvent<ClickEventData>
{

    public override ClickEventData Data { get; }

    public ClickEvent(GameObject obj)
    {
        Data = new ClickEventData(obj);
    }

}
