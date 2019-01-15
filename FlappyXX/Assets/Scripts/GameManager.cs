using UnityEngine.Events;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    // スコア
    public NotificationObject<int> Score = new NotificationObject<int>(0);

    // ゲームステータス
    public enum GameState
    {
        Title, Play, GameOver
    }
    public NotificationObject<GameState> gameState = new NotificationObject<GameState>(GameState.Play);

    void OnDestroy()
    {
        // 登録されたアクションを削除する
        Score.Dispose();
        gameState.Dispose();
    }

    

    /**
     * gameStateに登録できるアクションが1つだけだったので、
     * ゲームオーバー時の処理に不便（Player・UI・敵の生成、
     * それぞれにコールバックを送れない）そのための策
     **/
    public const int Title = 0;
    public const int Play = 1;
    public const int GameOver = 2;

    // コールバックイベントを変数として使うために空のクラスを用意する
    [System.Serializable]
    public class Callback : UnityEvent<int>    {    }
    // コールバックイベントの変数生成
    public static Callback StateChangeAction = new Callback();

    /**
     *ゲームステート
     * セッタが呼ばれたタイミング（ステート変更が起きたタイミング）で
     *  コールバックイベントを呼ぶ
     **/
    private static int state = Title;
    public static int State
    {
        get{return state;}
        set
        {
            state = value;
            if (StateChangeAction != null)
                StateChangeAction.Invoke(state);
        }
    }    
}


