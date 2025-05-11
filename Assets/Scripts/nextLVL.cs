using UnityEngine;

public class NextLVL : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Meta alcanzada!");
            GameManager.singleton.NextLevel();
        }
    } 
}
