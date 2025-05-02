using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.addScore(1);
    }
}
