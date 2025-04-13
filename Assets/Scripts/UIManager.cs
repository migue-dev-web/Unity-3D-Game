using UnityEngine;
using TMPro; 



public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoretext;

    public TextMeshProUGUI bestScoretext;

        void Update()
    {
        currentScoretext.text = "Score: " + GameManager.singleton.currentScore;
        bestScoretext.text = "Best: "+ GameManager.singleton.bestScore;
    }
}
