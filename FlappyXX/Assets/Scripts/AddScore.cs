using UnityEngine;

public class AddScore : MonoBehaviour {
    
    void OnTriggerExit(Collider collider)
    {
        // スコアを追加していく
        GameManager.Instance.Score.Value += 1;
    }

}
