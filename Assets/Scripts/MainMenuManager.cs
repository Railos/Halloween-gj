using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public GameObject mainCanvas;
    public GameObject settingsCanvas;

    [Header("Volume Slider")] 
    public Slider volumeSlider;
    public TMP_Text volumeValue;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        volumeValue.text = PlayerPrefs.GetFloat("Volume").ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeCanvas()
    {
        mainCanvas.SetActive(!mainCanvas.activeSelf);
        settingsCanvas.SetActive(!settingsCanvas.activeSelf);
    }

    public void ChangeVolume(float value)
    {
        PlayerPrefs.SetFloat("Volume", Mathf.Round(value));
        PlayerPrefs.Save();

        volumeValue.text = PlayerPrefs.GetFloat("Volume").ToString();

        foreach (var i in FindObjectsOfType<AudioSource>())
        {
            i.volume = PlayerPrefs.GetFloat("Volume") / 100f;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
