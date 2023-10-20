using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject canvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(!canvas.activeSelf);
            if (canvas.activeSelf) Time.timeScale = 0f;
            else Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        
        canvas.SetActive(false);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
