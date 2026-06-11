using System.Collections.Generic;
using UnityEngine;

public enum GameEventType
{
    GameStarted,
    PuzzleStarted,
    PuzzleEnded,
    GameOverStarted
}

public interface IEventListener
{
    void OnEvent(GameEventType eventType);
}

public static class GameEventDispatcher
{
    private static readonly Dictionary<GameEventType, List<IEventListener>> listeners =
        new Dictionary<GameEventType, List<IEventListener>>();

    public static void AddListener(GameEventType eventType, IEventListener listener)
    {
        if (listener == null)
            return;

        if (!listeners.TryGetValue(eventType, out List<IEventListener> eventListeners))
        {
            eventListeners = new List<IEventListener>();
            listeners.Add(eventType, eventListeners);
        }

        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public static void RemoveListener(GameEventType eventType, IEventListener listener)
    {
        if (listener == null)
            return;

        if (!listeners.TryGetValue(eventType, out List<IEventListener> eventListeners))
            return;

        eventListeners.Remove(listener);
    }

    public static void RaiseGameStarted()
    {
        Dispatch(GameEventType.GameStarted);
    }

    public static void RaisePuzzleStarted()
    {
        Dispatch(GameEventType.PuzzleStarted);
    }

    public static void RaisePuzzleEnded()
    {
        Dispatch(GameEventType.PuzzleEnded);
    }

    public static void RaiseGameOverStarted()
    {
        Dispatch(GameEventType.GameOverStarted);
    }

    private static void Dispatch(GameEventType eventType)
    {
        if (!listeners.TryGetValue(eventType, out List<IEventListener> eventListeners))
            return;

        IEventListener[] eventListenersSnapshot = eventListeners.ToArray();
        for (int i = 0; i < eventListenersSnapshot.Length; i++)
        {
            try
            {
                eventListenersSnapshot[i].OnEvent(eventType);
            }
            catch (System.Exception exception)
            {
                Debug.LogException(exception);
            }
        }
    }
}
