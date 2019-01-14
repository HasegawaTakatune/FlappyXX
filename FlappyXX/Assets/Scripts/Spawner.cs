using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject Boad;
    private bool doOnce = false;
    private bool end = false;

    private IEnumerator Spawn()
    {
        while (true)
        {
            // Instantiateでオブジェクトの生成
            // 引数(１．オブジェクト　２．座標　３．向き)
            GameObject obj = GameObject.Instantiate(Boad,
                new Vector3(10, Random.Range(6f, 0f), 10),
                Quaternion.identity);

            // n秒間待ち状態になる
            yield return new WaitForSeconds(2.0f);

            if (end) break;
        }
    }

    void SpawnerControl(int state)
    {
        switch (state)
        {
            case GameManager.Play:
                if (!doOnce)
                {
                    StartCoroutine("Spawn");
                    doOnce = true;
                }
                break;

            case GameManager.GameOver:
                end = true;
                break;

            case GameManager.Title:
                doOnce = false;
                break;
        }
    }

	void Start () {
        //StartCoroutine("Spawn");
        GameManager.StateChangeAction.AddListener(SpawnerControl);
	}
	
	void Update () {
		
	}
}
