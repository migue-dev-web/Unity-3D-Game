using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bestScore;
    public int currentScore;

    public int currentLevel = 0;

    public static GameManager singleton;
    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this){
            Destroy(gameObject);
        }

        bestScore = PlayerPrefs.GetInt("HighScore");
    }

   public void NextLevel(){

   }

   public void restartLevel(){
    Debug.Log("Reinicio");
    singleton.currentScore = 0 ;
    FindAnyObjectByType<BallController>().resetBall();
   }

   public void addScore(int scoreToAdd){
    currentScore += scoreToAdd;

    if (currentScore > bestScore){

        bestScore = currentScore;
        PlayerPrefs.SetInt("HighScore",currentScore);
    }
   }
}
