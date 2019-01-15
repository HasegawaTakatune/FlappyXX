using UnityEngine;

public class Floor : MonoBehaviour {

    [SerializeField]float Speed = -1;
    float Current;
    Material material;

	void Start ()
    {
        material = GetComponent<Renderer>().material;
	}
	
	void Update ()
    {
        // マテリアルをスクロールさせて床が移動している様に見せる
        Current += Time.deltaTime * Speed;

        material.SetTextureOffset("_MainTex", new Vector2(Current, 0));
	}
}
