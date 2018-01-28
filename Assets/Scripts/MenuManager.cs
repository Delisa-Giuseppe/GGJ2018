using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	
    public void StartGame()
    {
        SceneManager.LoadScene("Level_Design");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
