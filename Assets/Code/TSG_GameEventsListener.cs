using System.Collections.Generic;
using UnityEngine;

public class TSG_GameEventsListener : MonoBehaviour
{
    [SerializeField] List<TSG_GameEventResponses> gameEventResponses = new List<TSG_GameEventResponses>();

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

    public void Invoke(TSG_GameEvent _gameEvent)
    {
        for (int i = 0; i < gameEventResponses.Count; i++)
        {
            if (gameEventResponses[i].GameEvent == _gameEvent)
            {
                gameEventResponses[i].Response?.Invoke();
            }
        }
    }
}
