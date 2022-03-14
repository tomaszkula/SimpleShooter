using System;
using UnityEngine.Events;

[Serializable]
public class SS_GameEventResponses
{
    public SS_GameEvent GameEvent = null;
    public UnityEvent<SS_GameEventData> Response = null;
}