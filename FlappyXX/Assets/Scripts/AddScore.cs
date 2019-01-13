using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    void OnTriggerExit(Collider collider)
    {
        GameManager.Instance.Score.Value += 1;
    }

}
