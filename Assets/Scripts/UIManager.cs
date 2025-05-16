using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text;



public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoretext;

    public TextMeshProUGUI bestScoretext;
    public Slider slider;
    public TextMeshProUGUI nLevel;
    public TextMeshProUGUI aLevel;

    public Transform topTransform;
    public Transform goalTransform;
     public Transform ball;
     private int previousScore = -1;
    private StringBuilder builder = new StringBuilder(32);

        void Update()
    {
        int currentScore = GameManager.singleton.currentScore;
        if (currentScore != previousScore)
        {
            builder.Clear();
            builder.Append("Score: ");
            builder.Append(currentScore);
            currentScoretext.text = builder.ToString();
            previousScore = currentScore;
        }
        bestScoretext.text = "Best: "+ GameManager.singleton.bestScore;
        ChangeSliderLevelandProgress();
    }

    public void ChangeSliderLevelandProgress(){
        aLevel.text = "" + (GameManager.singleton.currentLevel+1);
        nLevel.text = "" + (GameManager.singleton.currentLevel+2);

        float totalDistance = (topTransform.position.y -goalTransform.position.y );

        float distanceLeft = totalDistance - (ball.position.y - goalTransform.position.y);

        float value = (distanceLeft / totalDistance);

        slider.value = Mathf.Lerp(slider.value,value,5);
    }
}
