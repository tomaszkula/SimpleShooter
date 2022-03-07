using System;
using UnityEngine.Events;

[Serializable]
public class TSG_GameEventResponses
{
    public TSG_GameEvent GameEvent = null;
    public UnityEvent<TSG_GameEventData> Response = null;
}