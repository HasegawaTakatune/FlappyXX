using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    public NotificationObject<int> Score = new NotificationObject<int>(0);


    public enum GameState
    {
        Title, Play, GameOver
    }
    public const int Title = 0;
    public const int Play = 1;
    public const int GameOver = 2;

    public NotificationObject<GameState> gameState = new NotificationObject<GameState>(GameState.Play);

    void OnDestroy()
    {
        Score.Dispose();

        gameState.Dispose();
    }

    //*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/
    [System.Serializable]
    public class Callback : UnityEvent<int>
    {

    }
    private static int state = Title;
    public static int State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
            if (StateChangeAction != null)
                StateChangeAction.Invoke(state);
        }
    }
    public static Callback StateChangeAction = new Callback();
}


