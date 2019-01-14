using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]private Rigidbody rigid;
    [SerializeField]private float jumpPower = 1;
    private bool jumpRequest = false;

    // 初期化処理
	void Start () {
        // コンポーネントを取得
        rigid = GetComponent<Rigidbody>();

        // ゲームステート変更通知の登録
        ChangeGameState(GameManager.Instance.gameState.Value);
        GameManager.Instance.gameState.action += ChangeGameState;

        //GameManager.State = GameManager.Play;
        GameManager.StateChangeAction.AddListener(ChangeGameState);
	}
	
    // 毎秒不規則回数呼ばれるループ
	void Update ()
    {
        // 入力判定
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequest = true;
        }
    }

    // 指定フレームレートで呼ばれるループ
    void FixedUpdate()
    {
        if(jumpRequest)
        {
            jumpRequest = false;
            // ベクトル移動させる
            rigid.velocity = Vector3.up * jumpPower;
        }
    }

    // 当たり判定
    void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.gameState.Value = GameManager.GameState.GameOver;
        GameManager.State = GameManager.GameOver;
    }

    void OnDestroy()
    {
        // 通知の解除
        if (GameManager.Instance != null)
        {
            GameManager.Instance.gameState.action -= ChangeGameState;
        }
    }

    // ゲームステートごとの処理
    void ChangeGameState(GameManager.GameState state)
    {
        switch (state)
        {
            case GameManager.GameState.GameOver:
                // ゲームオーバー時にUpdateを停止する
                enabled = false;
                Debug.Log("Player change state");
                break;
        }
    }

    void ChangeGameState(int state)
    {
        switch (state)
        {
            case GameManager.GameOver:
                // ゲームオーバー時にUpdateを停止する
                enabled = false;
                Debug.Log("Player change state<int>");
                break;

            case GameManager.Play:
                Debug.Log("Call ChangeGameState (State -> Play)");
                rigid.useGravity = true;
                break;

            case GameManager.Title:
                rigid.useGravity = false;
                break;
        }
    }
}
