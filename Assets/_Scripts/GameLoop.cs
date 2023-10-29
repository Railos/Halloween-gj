using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoop : Singleton<GameLoop>
{
    public int soulsLeft, maxSoulsCount;
    public CanvasGroup gameOverScreen;
    public TextMeshProUGUI soulsCount;
    public Image soulsCountBar;
    public string countText;
    public CanvasGroup winScreen;
    public TMP_Text timerText;

    public float winTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        soulsLeft = maxSoulsCount;
        soulsCount.text = string.Format(countText, soulsLeft, maxSoulsCount);
        soulsCountBar.fillAmount = (float) soulsLeft / (float) maxSoulsCount;
    }

    // Update is called once per frame
    void Update()
    {
        winTimer -= Time.deltaTime;
        if (winTimer < 0.1f)
        {
            timerText.gameObject.SetActive(false);
            YouWin();
        }

        timerText.text = (Mathf.Round(winTimer * 10f) * 0.1f).ToString();
    }

    public void DecreaseSoulsCount()
    {
        soulsLeft--;
        if (soulsLeft <= 0)
        {
            GameOver();
        }

        soulsCount.text = string.Format(countText, soulsLeft, maxSoulsCount);
        soulsCountBar.fillAmount = (float) soulsLeft / (float) maxSoulsCount;
    }

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverScreen.DOFade(1f, 0.3f);
    }

    public void YouWin()
    {
        winScreen.gameObject.SetActive(true);
        winScreen.DOFade(1f, 0.3f);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
