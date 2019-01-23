using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#pragma warning disable 0649
public class MenuUI : MonoBehaviour {

    [SerializeField]Text Title;
    [SerializeField]Text GameOver;

    bool doOnce = false;

	void Start ()
    {
        // コールバックの設定
        GameManager.StateChangeAction.AddListener(MenuControl);
	}

    void OnDestroy()
    {
        // コールバックを解除
        GameManager.StateChangeAction.RemoveListener(MenuControl);
    }

    void Update()
    {
        // ボタンクリックでゲームスタート
        if (GameManager.State == GameManager.Title && Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.State = GameManager.Play;
        }
    }
      
    void MenuControl(int state)
    {
        // ゲームステータスごとの処理
        switch (state)
        {
            case GameManager.Play:
                Title.enabled = false;
                break;

            case GameManager.GameOver:
                if (!doOnce)
                {
                    doOnce = true;
                    GameOver.enabled = true;
                    StartCoroutine("ReturnScene");
                }
                break;

            case GameManager.Title:
                Title.enabled = true;
                break;
        }
    }

    // ゲームを初期状態に戻す（リロード）
    private IEnumerator ReturnScene()
    {
        float timer = 15f;
        while (true)
        {
            timer -= 1f;
            GameOver.text = "GameOver\nNext " + (Mathf.Floor(timer) / 10).ToString("0.0");
            if (timer <= 0) break;
            yield return new WaitForSeconds(0.1f);
        }
        GameManager.State = GameManager.Title;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}