using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("newBase");
    }

    
    public void exitGame()
    {
        Debug.Log("Cerrando aplicacion");
        Application.Quit();
    }

    public void MainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}
