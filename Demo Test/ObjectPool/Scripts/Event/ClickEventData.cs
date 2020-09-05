using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventData : AbstractEventData
{
    public GameObject obj;

    public ClickEventData(GameObject go)
    {
        obj = go;
        eventType = EventType.ClickEventType;
    }
}
