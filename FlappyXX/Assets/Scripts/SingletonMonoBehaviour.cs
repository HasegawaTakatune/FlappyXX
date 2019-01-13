﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T :MonoBehaviour {

    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                Type t = typeof(T);

                instance = (T)FindObjectOfType(t);
                if(instance == null)
                {
                    Debug.LogError(t + "をアタッチしているGameObjectはありません");
                }
            }
            return instance;
        }
    }

    virtual protected void Awake()
    {
        // 他のGameObjectにアタッチされているか調べ
        // アタッチされていれば破棄する
        if(this != Instance)
        {
            Destroy(this);

            Debug.LogError(typeof(T) +
                "は既に他のGameObjectにアタッチされているため、コンポーネントを破棄しました。" +
                "アタッチされているGameObjectは" + Instance.gameObject.name + "です。");
            return;
        }

        // なんとかManager的なSceneを跨いでこのGameObjectを有効にしたい場合は
        // ↓コメントアウト外してください.
        //DontDestroyOnLoad(this.gameObject);
    }
}
