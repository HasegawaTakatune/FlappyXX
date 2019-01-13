using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    [SerializeField]float Speed = -1;
    float Current;
    Material material;

	void Start () {
        material = GetComponent<Renderer>().material;
	}
	
	void Update () {
        Current += Time.deltaTime * Speed;

        material.SetTextureOffset("_MainTex", new Vector2(Current, 0));
	}
}
