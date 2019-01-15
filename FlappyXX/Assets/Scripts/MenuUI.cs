using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

    [SerializeField]
    Text Title;

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
        if (GameManager.State == GameManager.Title & Input.GetKeyDown(KeyCode.Return))
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
                Title.enabled = true;
                StartCoroutine("ReturnScene");
                break;

            case GameManager.Title:
                Title.enabled = true;
                break;
        }
    }

    // ゲームを初期状態に戻す（リロード）
    private IEnumerator ReturnScene()
    {
        yield return new WaitForSeconds(5.0f);
        GameManager.State = GameManager.Title;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}