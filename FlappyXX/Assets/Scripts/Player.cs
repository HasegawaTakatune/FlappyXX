﻿using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]private Rigidbody rigid;
    [SerializeField]private float jumpPower = 1;
    private bool jumpRequest = false;
    private bool control = false;

    // 初期化処理
	void Start () {
        // コンポーネントを取得
        rigid = GetComponent<Rigidbody>();

        // ゲームステート変更通知の登録
        GameManager.StateChangeAction.AddListener(ChangeGameState);
	}
	
    // 毎秒不規則回数呼ばれるループ
	void Update ()
    {
        // 入力判定
        if (control && Input.GetKeyDown(KeyCode.Space))
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
        GameManager.State = GameManager.GameOver;
    }

    void OnDestroy()
    {
        // 通知の解除
        GameManager.StateChangeAction.RemoveListener(ChangeGameState);

    }

    // ゲームステートごとの処理
    void ChangeGameState(int state)
    {
        switch (state)
        {
            case GameManager.GameOver:
                // ゲームオーバー時にUpdateを停止する
                enabled = false;
                break;

            case GameManager.Play:
                rigid.useGravity = true;
                control = true;
                break;

            case GameManager.Title:
                rigid.useGravity = false;
                break;
        }
    }
}
