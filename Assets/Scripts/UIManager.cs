using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;



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

        void Update()
    {
        currentScoretext.text = "Score: " + GameManager.singleton.currentScore;
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
