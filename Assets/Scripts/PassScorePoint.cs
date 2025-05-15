using UnityEngine;

public class PassScorePoint : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.addScore(1);
        FindAnyObjectByType<BallController>().perfectPass++;
    }
}
