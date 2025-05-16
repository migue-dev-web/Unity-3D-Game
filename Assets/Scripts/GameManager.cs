using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bestScore;
    public int currentScore;
    public int currentLevel = 0;

    public int total;

    public static GameManager singleton;
    void Awake()
    {
        
        QualitySettings.vSyncCount = 0;
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }

        bestScore = PlayerPrefs.GetInt("HighScore");
        
    }
    void Start()
    {
       total = FindAnyObjectByType<HelixController>().allStages.Count; 
    }

   public void NextLevel()
    {
        currentLevel++;

        if (currentLevel >= total )
        {
            currentLevel = 0;
        }

        FindAnyObjectByType<BallController>().resetBall();

        FindAnyObjectByType<HelixController>().loadStage(currentLevel);
        Debug.Log(currentLevel);
        Debug.Log("NIVELES" + total);
    }



    public void restartLevel(){
    Debug.Log("Reinicio");
    singleton.currentScore = 0 ;
    FindAnyObjectByType<BallController>().resetBall();
    FindAnyObjectByType<HelixController>().loadStage(currentLevel);
   }

   public void addScore(int scoreToAdd){
    currentScore += scoreToAdd;

    if (currentScore > bestScore){

        bestScore = currentScore;
        PlayerPrefs.SetInt("HighScore",currentScore);
    }
   }
}
