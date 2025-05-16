using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("newBase");
        Debug.Log("StartGame presionado");
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
