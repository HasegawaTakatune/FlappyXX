using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour {

    [SerializeField]
    Text Title;

	void Start () {
        //GameManager.Instance.gameState.action += MenuControl;
        
	}

    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            //GameManager.Instance.gameState.action -= MenuControl;
        }
    }

    void MenuControl(GameManager.GameState state)
    {
        switch (state)
        {
            case GameManager.GameState.GameOver:
                Title.enabled = false;
                break;

            case GameManager.GameState.Play:
                Title.enabled = false;
                break;

            case GameManager.GameState.Title:
                break;
        }
        Debug.Log("MenuUI change state");
    }
}
