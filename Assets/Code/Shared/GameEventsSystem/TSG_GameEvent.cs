using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gameEvent_NewGameEvent", menuName = "TSG/Game Event")]
public class TSG_GameEvent : ScriptableObject
{
    List<TSG_GameEventsListener> gameEventListeners = new List<TSG_GameEventsListener>();

    public void Register(TSG_GameEventsListener _gameEventListener)
    {
        gameEventListeners.Add(_gameEventListener);
    }

    public void Unregister(TSG_GameEventsListener _gameEventListener)
    {
        gameEventListeners.Remove(_gameEventListener);
    }

    public void Invoke()
    {
        for (int i = 0; i < gameEventListeners.Count; i++)
        {
            gameEventListeners[i]?.Invoke(this);
        }
    }

    public void Invoke(TSG_GameEventData _gameEventData)
    {
        for (int i = 0; i < gameEventListeners.Count; i++)
        {
            gameEventListeners[i]?.Invoke(this, _gameEventData);
        }
    }
}
