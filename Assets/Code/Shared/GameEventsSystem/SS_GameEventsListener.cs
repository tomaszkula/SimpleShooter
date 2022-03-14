using System.Collections.Generic;
using UnityEngine;

public class SS_GameEventsListener : MonoBehaviour
{
    [SerializeField] List<SS_GameEventResponses> gameEventResponses = new List<SS_GameEventResponses>();

    private void OnEnable()
    {
        for (int i = 0; i < gameEventResponses.Count; i++)
        {
            gameEventResponses[i].GameEvent.Register(this);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < gameEventResponses.Count; i++)
        {
            gameEventResponses[i].GameEvent.Unregister(this);
        }
    }

    public void Invoke(SS_GameEvent _gameEvent)
    {
        Invoke(_gameEvent, default);
    }

    public void Invoke(SS_GameEvent _gameEvent, SS_GameEventData _gameEventData)
    {
        for (int i = 0; i < gameEventResponses.Count; i++)
        {
            if (gameEventResponses[i].GameEvent == _gameEvent)
            {
                gameEventResponses[i].Response?.Invoke(_gameEventData);
            }
        }
    }
}
