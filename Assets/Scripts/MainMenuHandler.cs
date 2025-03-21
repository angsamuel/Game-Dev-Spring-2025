using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void StartGame(){
        Debug.Log("Starting Game!");
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame(){
        Debug.Log("Quitting Game!");
        Application.Quit();
    }
}
