using UnityEngine;

#pragma warning disable 0649
public class Block : MonoBehaviour {

    [SerializeField]private Rigidbody rigid;
    [SerializeField]private float Speed = 1;

    void FixedUpdate()
    {
        // オブジェクト移動
        rigid.velocity = -Vector3.right * Speed;
    }
}
