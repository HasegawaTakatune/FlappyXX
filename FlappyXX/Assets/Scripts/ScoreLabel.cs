using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabel : MonoBehaviour {

    Text text;

	void Start () {
        text = GetComponent<Text>();
        // 事前に更新
        ChangeScore(GameManager.Instance.Score.Value);
        // 変更通知を登録
        GameManager.Instance.Score.action += ChangeScore;
	}

    void OnDestroy()
    {
        // 登録した変更通知を解除
        if(GameManager.Instance != null)
        {
            GameManager.Instance.Score.action -= ChangeScore;
        }
    }

    void ChangeScore(int score)
    {
        text.text = score.ToString();
    }
	
}
