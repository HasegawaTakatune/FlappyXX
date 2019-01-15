using UnityEngine;

public class Destoryer : MonoBehaviour {

    void OnTriggerExit(Collider collider)
    {
        // オブジェクトの削除
        Destroy(collider.gameObject );
    }
}
