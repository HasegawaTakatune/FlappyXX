using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

    [SerializeField]
    Text Title;

	void Start () {
        //GameManager.Instance.gameState.action += MenuControl;
        GameManager.StateChangeAction.AddListener(MenuControl);
	}

    void Update()
    {
        if (GameManager.State == GameManager.Title & Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.State = GameManager.Play;
        }
    }

    void OnDestroy()
    {
        
    }

    void MenuControl(int state)
    {
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
        Debug.Log("MenuUI change state");
    }

    private IEnumerator ReturnScene()
    {
        yield return new WaitForSeconds(5.0f);
        GameManager.State = GameManager.Title;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}