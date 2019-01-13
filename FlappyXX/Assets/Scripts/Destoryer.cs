using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoryer : MonoBehaviour {

    void OnTriggerExit(Collider collider)
    {
        Destroy(collider.gameObject );
    }
}
