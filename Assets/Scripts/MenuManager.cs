using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	
    public void StartGame()
    {
        SceneManager.LoadScene("Level Design 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
