using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject mainCanvas;
    public GameObject settingsCanvas;
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeCanvas()
    {
        mainCanvas.SetActive(!mainCanvas.activeSelf);
        settingsCanvas.SetActive(!settingsCanvas.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
