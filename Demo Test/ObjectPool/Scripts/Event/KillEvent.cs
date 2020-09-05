using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEvent : BaseEvent<KillEventData>
{
    public override KillEventData Data { get; }

    public KillEvent(GameObject k, GameObject v)
    {
        Data = new KillEventData(k, v);
    }
}
