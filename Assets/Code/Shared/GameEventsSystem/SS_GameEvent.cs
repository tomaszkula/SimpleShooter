using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gameEvent_NewGameEvent", menuName = "TSG/Game Event")]
public class SS_GameEvent : ScriptableObject
{
    List<SS_GameEventsListener> gameEventListeners = new List<SS_GameEventsListener>();

    public void Register(SS_GameEventsListener _gameEventListener)
    {
        gameEventListeners.Add(_gameEventListener);
    }

    public void Unregister(SS_GameEventsListener _gameEventListener)
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

    public void Invoke(SS_GameEventData _gameEventData)
    {
        for (int i = 0; i < gameEventListeners.Count; i++)
        {
            gameEventListeners[i]?.Invoke(this, _gameEventData);
        }
    }
}
