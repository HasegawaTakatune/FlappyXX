using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField]private Rigidbody rigid;
    [SerializeField]private float Speed = 1;

	void Start ()
    {
    }
	
	void Update () {
		
	}

    void FixedUpdate()
    {
        rigid.velocity = -Vector3.right * Speed;
    }
}
