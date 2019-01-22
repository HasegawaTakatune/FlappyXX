using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

    [SerializeField]
    Text Title;
    [SerializeField]
    Text GameOver;

    bool doOnce = false;

	void Start () {
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
                    StartCoroutine("TimeCount");
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
        yield return new WaitForSeconds(3.0f);
        GameManager.State = GameManager.Title;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator TimeCount()
    {
        float timer = 28f;
        while (true)
        {
            timer -= 1f;
            GameOver.text = "GameOver\nNext "+ (Mathf.Floor(timer) / 10).ToString ("0.0");
            yield return new WaitForSeconds(0.1f);


        }
    }
}