using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEventData : AbstractEventData
{
    public GameObject killer;
    public GameObject victim;

    public KillEventData(GameObject k, GameObject v)
    {
        killer = k;
        victim = v;
        eventType = EventType.KillEventType;
    }
}
